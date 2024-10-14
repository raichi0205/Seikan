using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Star.Common;
using Star.Character;
using Star.Battle.UI;
using Cysharp.Threading.Tasks;
using Star.Sound;

namespace Star.Battle
{
    public class BattleSystem : SingletonMonoBehaviour<BattleSystem>
    {
        public enum TurnAction
        {
            None = -1,
            TurnStart,          // ターン開始
            SelectAction,       // 行動選択
            SelectEnemy,        // 目標選択
            ActionTurn,         // 行動ターン
            TurnEnd,            // ターン終了
            Num,
        }

        const int maxTurn = 999;    // 最大ターン数
        [SerializeField] int turn = 0;           // 現在のターン

        [SerializeField] SkillManager skillManager;
        [SerializeField] EnemyManager enemyManager;
        public EnemyManager EnemyManager { get { return enemyManager; } }

        // 敵キャラの選択システム
        private EnemySelector enemySelector = new EnemySelector();
        public EnemySelector EnemySelector { get { return enemySelector; } }

        [SerializeField] BattleUI battleUI;      // 戦闘画面UI
        public BattleUI BattleUI { get { return battleUI; } }

        ActionScheduler actionScheduler = new ActionScheduler();
        public TurnAction turnAction = TurnAction.None;

        // プレイヤー行動データ
        public SelectData CurrentSelectData = null;
        private List<SelectData> playerSelectDatas = new List<SelectData>();
        public List<SelectData> PlayerSelectDatas { get { return playerSelectDatas; } }
        private List<SelectData> selectDatas = new List<SelectData>();
        public List<SelectData> SelectDatas { get { return selectDatas; } }

        // システムメッセージ
        string systemMsg = "";
        public string SystemMsg { get { return systemMsg; } 
            set
            {
                if (battleUI != null && battleUI.SystemMsgUi != null)
                {
                    battleUI.SystemMsgUi.text = systemMsg = value;
                }
            }
        }

        [SerializeField] ActorData actorData;

        [SerializeField] private Actor actor = new Actor();                  // 主人公
        public Actor Actor { get { return actor; } }

        private void Start()
        {
            Initialize();
        }

        /// <summary>
        /// 初期化処理
        /// ToDo: 非同期にして初期化処理が終了するまでロード画面で止めるなどの工夫
        /// </summary>
        public async UniTask Initialize()
        {
            await SoundManager.Instance.LoadAudios(SoundManager.MixerGroup.SE, "SE");
            await Effect.EffectSystem.Instance.LoadEffectAssets();

            Lua.LuaSystem.Instance.StarLua("Battle/Main.lua");

            skillManager.Initialize();
            enemyManager.Initialize();

            actor.Initialize(actorData, -2);

            ActionSelector.Instance.Initialize();

            // UIは最後に初期化
            battleUI.Initialize();

            NextTurnAction();
        }

        public async UniTask NextTurnAction(TurnAction _designationAction = TurnAction.None)
        {
            if (_designationAction == TurnAction.None)
            {
                // 次の行動を示す
                turnAction = turnAction < TurnAction.Num - 1 ? turnAction + 1 : TurnAction.TurnStart;
            }
            else
            {
                // 指定の行動を示す
                turnAction = _designationAction;        
            }
            Debug.Log($"[BattleSystem] TurnAction:{turnAction}");

            switch (turnAction)
            {
                case TurnAction.TurnStart:
                    await TurnStart();
                    break;
                case TurnAction.SelectAction:
                    await SelectAction();
                    break;
                case TurnAction.SelectEnemy:
                    await SelectEnemy();
                    break;
                case TurnAction.ActionTurn:
                    await ActionTurn();
                    break;
                case TurnAction.TurnEnd:
                    await TurnEnd();
                    break;
            }
        }

        /// <summary>
        /// ターンの開始
        /// </summary>
        private async UniTask TurnStart()
        {
            Debug.Log($"[BattleSystem] TurnStart:{turn}");

            playerSelectDatas.Clear();        // 選択内容をリセット
            CurrentSelectData = null;
            selectDatas.Clear();
            actor.SelectCounter = 0;

            if(turn < maxTurn)
            { 
                turn++;     // ターンを一つ繰り上げる
                // Todo: ターン開始時の演出
                // プレイヤーの状態の更新
                actor.UpdateStatus();
                // 敵の状態の更新
                foreach(var enemy in enemyManager.Enemies)
                {
                    enemy.UpdateStatus();
                }

                NextTurnAction();
            }
            else
            {
                // 規定ターン数をオーバー、戦闘終了 敗北扱い
            }
        }

        private async UniTask SelectAction()
        {
            Debug.Log("[BattleSystem] SelectAction");

            if (CurrentSelectData == null)
            {
                CurrentSelectData = new SelectData();       // 新しい選択情報の作成
                playerSelectDatas.Add(CurrentSelectData);
            }

            battleUI.OpenActionSelectWindow();
        }

        private async UniTask SelectEnemy()
        {
            Debug.Log("[BattleSystem] SelectEnemy");
            if(CurrentSelectData.Action.DefaultTargetNum == -2)
            {
                CurrentSelectData.Executor = actor;
                CurrentSelectData.Target = CurrentSelectData.Action.DefaultTargetNum;
                NextTurnAction();       // 自分が対象の場合はスキップ
                return;
            }
            battleUI.CloseActionSelectWindow();
            battleUI.ActiveTargetEnemySelect();
        }

        private async UniTask ActionTurn()
        {
            // 行動選択権がまだ残っているか
            //Debug.Log($"[Debug] {actor.GetSelectCount() > 0} : {actor.GetSelectCount()}");
            if(actor.GetSelectCount() > 0)
            {
                // 残っていれば選択画面に戻す
                CurrentSelectData = null;       // 選択データも一新する
                NextTurnAction(TurnAction.SelectAction);
                return;
            }

            Debug.Log("[BattleSystem] ActionTurn");

            battleUI.CloseActionSelectWindow();
            battleUI.UnActiveTargetEnemySelect();

            // 敵の行動選択
            await enemyManager.EnemyActionThinking();
            selectDatas.AddRange(playerSelectDatas);        // プレイヤーの行動データを追加

            await actionScheduler.Action();
        }

        private async UniTask TurnEnd()
        {
            Debug.Log("[BattleSystem] TurnEnd");
            NextTurnAction();
        }

        public async UniTask ActionExecute(SelectData _selectData)
        {
            Debug.Log($"[BattleSystem][ActionExe] Action:{_selectData.Action.Chara}\nTarget:{_selectData.Target}");
            if(_selectData.Target == int.MinValue)
            {
                Debug.LogError("ターゲット未選択");
            }
            else if(_selectData.Target == -1)
            {
                // 全体攻撃
                _selectData.Action.ActionToEnemy(enemyManager.Enemies);
            }
            else if(_selectData.Target == -2)
            {
                // 自身への行動
                await _selectData.Action.Action(_selectData.Executor, actor);
            }
            else
            {
                if (_selectData.Target < enemyManager.Enemies.Count)
                {
                    await _selectData.Action.Action(_selectData.Executor, enemyManager.Enemies[_selectData.Target]);
                }
                else
                {
                    Debug.LogError("[BS Select]Index over");
                }
            }
            SystemMsg = $"";
            await UniTask.Delay(250);
        }
    }
}