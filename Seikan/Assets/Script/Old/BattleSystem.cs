using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Star.Common;
using Star.Old.Character;
using Star.Old.Battle.UI;
using Cysharp.Threading.Tasks;
using Star.Sound;

namespace Star.Old.Battle
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

        public enum TurnEndSatuts
        {
            None = -1,
            Continue = 0,
            Win = 1,
            Defeat = 2,
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
            await Effect.Effekseer.EffectSystem.Instance.LoadEffectAssets();        // Todo: 後で消す
            await Effect.SpriteEffectManager.Instance.LoadEffectAssets();

            Lua.LuaSystem.Instance.StarLua("Battle/Main.lua");

            await skillManager.Initialize();
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
                foreach(var enemy in enemyManager.FieldEnemies)
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
            // todo: 状態異常の処理


            TurnEndSatuts turnEndSatuts = TurnEndSatuts.Win;

            // 自分がまだ生きてるか
            if (actor.currentStatus[(int)Status.HP] <= 0)
            {
                // 死んでるので敗北
                turnEndSatuts = TurnEndSatuts.Defeat;
            }
            else
            {
                // 敵がまだ生きてるか
                foreach (Enemy enemy in enemyManager.Enemies)
                {
                    if (enemy.currentStatus[(int)Status.HP] > 0)
                    {
                        // 敵が生きてるので続行
                        turnEndSatuts = TurnEndSatuts.Continue;
                    }
                }
            }

            switch (turnEndSatuts)
            {
                case TurnEndSatuts.Continue:
                    NextTurnAction();
                    break;
                case TurnEndSatuts.Win:
                    // Todo: 勝利演出を出す
                    Debug.Log($"[Result] win");
                    break;
                case TurnEndSatuts.Defeat:
                    // Todo: 敗北UIを出す
                    Debug.Log($"[Result] defeat");
                    break;
            }

        }

        public async UniTask ActionExecute(SelectData _selectData)
        {
            Debug.Log($"[BattleSystem][ActionExe] Action:{_selectData.Action.Chara}\nTarget:{_selectData.Target}");
            // 死亡しているか
            if(_selectData.Executor.currentStatus[(int)Status.HP] <= 0)
            {
                // 実行者が死亡している場合は処理を飛ばす
                return;
            }

            if(_selectData.Target == int.MinValue)
            {
                Debug.LogError("ターゲット未選択");
            }
            else if(_selectData.Target == -1)
            {
                // 全体攻撃
                await _selectData.Action.Action(_selectData.Executor, new List<CharacterBase>(enemyManager.FieldEnemies));
            }
            else if(_selectData.Target == -2)
            {
                // 自身への行動
                await _selectData.Action.Action(_selectData.Executor, new List<CharacterBase>() { actor });
            }
            else
            {
                // 敵への行動
                if (_selectData.Target < enemyManager.Enemies.Count)
                {
                    bool allDead = true;

                    // ターゲットが生きてるか調べる
                    Enemy targetEnemy = enemyManager.Enemies[_selectData.Target];
                    if (targetEnemy.currentStatus[(int)Status.HP] <= 0)
                    {
                        // 死んでいれば次のターゲットを探す
                        foreach (Enemy enemy in enemyManager.FieldEnemies)
                        {
                            if (enemy.currentStatus[(int)Status.HP] > 0)
                            {
                                // 生きているやつがいればそいつをターゲットにする
                                targetEnemy = enemy;
                                allDead = false;        // 全滅していない
                                break;
                            }
                        }
                    }
                    else
                    {
                        // ターゲットは生きている
                        allDead = false;
                    }

                    if (allDead)
                    {

                    }
                    else
                    {
                        await _selectData.Action.Action(_selectData.Executor, new List<CharacterBase>() { targetEnemy });
                    }
                }
                else
                {
                    Debug.LogError("[BS Select]Index over");
                }
            }
            SystemMsg = $"";
            await UniTask.Delay(250);
            // HPの判定
            bool isActorDeth = await Actor.CheckHP();
            // 主人公のHPはまだ残っている
            if (!isActorDeth)
            {
                // 敵のHP判定
                await EnemyManager.CheckHP();
            }
        }
    }
}