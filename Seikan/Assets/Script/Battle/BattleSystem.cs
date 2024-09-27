using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Star.Common;
using Star.Character;
using Star.Battle.UI;

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

        // 敵キャラの選択システム
        private EnemySelector enemySelector = new EnemySelector();
        public EnemySelector EnemySelector { get { return enemySelector; } }

        [SerializeField] BattleUI battleUI;      // 戦闘画面UI

        ActionScheduler actionScheduler = new ActionScheduler();
        List<UnityAction> schedule = new List<UnityAction>();
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
        private Actor actor = new Actor();                  // 主人公
        public Actor Actor { get { return actor; } }

        private void Start()
        {
            Initialize();
        }

        /// <summary>
        /// 初期化処理
        /// ToDo: 非同期にして初期化処理が終了するまでロード画面で止めるなどの工夫
        /// </summary>
        public void Initialize()
        {
            skillManager.Initialize();
            enemyManager.Initialize();
            battleUI.Initialize();

            actor.Initialize(actorData);

            schedule.Add(TurnStart);
            schedule.Add(SelectAction);
            schedule.Add(SelectEnemy);
            schedule.Add(ActionTurn);
            schedule.Add(TurnEnd);

            ActionSelector.Instance.Initialize();

            NextTurnAction();
        }

        public void NextTurnAction(TurnAction _designationAction = TurnAction.None)
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
            schedule[(int)turnAction].Invoke();
        }

        /// <summary>
        /// ターンの開始
        /// </summary>
        private void TurnStart()
        {
            Debug.Log($"[BattleSystem] TurnStart:{turn}");

            playerSelectDatas.Clear();        // 選択内容をリセット
            CurrentSelectData = null;
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

        private void SelectAction()
        {
            Debug.Log("[BattleSystem] SelectAction");

            if (CurrentSelectData == null)
            {
                CurrentSelectData = new SelectData();       // 新しい選択情報の作成
                playerSelectDatas.Add(CurrentSelectData);
            }

            battleUI.OpenActionSelectWindow();
        }

        private void SelectEnemy()
        {
            Debug.Log("[BattleSystem] SelectEnemy");
            if(CurrentSelectData.Action.DefaultTargetNum == -2)
            {
                CurrentSelectData.Target = CurrentSelectData.Action.DefaultTargetNum;
                NextTurnAction();       // 自分が対象の場合はスキップ
                return;
            }
            battleUI.CloseActionSelectWindow();
            battleUI.ActiveTargetEnemySelect();
        }

        private void ActionTurn()
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

            // ToDo: 敵の行動選択
            // Memo: Luaでやる。行動選択処理をLuaでを行い、完了まで待機する
            selectDatas.AddRange(playerSelectDatas);        // プレイヤーの行動データを追加
            actionScheduler.Action();
        }

        private void TurnEnd()
        {
            Debug.Log("[BattleSystem] TurnEnd");
            NextTurnAction();
        }

        public void ActionExecute(SelectData _selectData)
        {
            Debug.Log($"[BattleSystem][ActionExe] Action:{_selectData.Action.Chara}\nTarget:{_selectData.Target}");
            if(_selectData.Target == int.MinValue)
            {
                Debug.LogError("ターゲット未選択");
            }
            else if(_selectData.Target == -1)
            {
                // 全体攻撃
                _selectData.Action.Action(enemyManager.Enemies);
            }
            else if(_selectData.Target == -2)
            {
                // 自身への行動
                _selectData.Action.Action(actor);
            }
            else
            {
                if (_selectData.Target < enemyManager.Enemies.Count)
                {
                    _selectData.Action.Action(enemyManager.Enemies[_selectData.Target]);
                }
                else
                {
                    Debug.LogError("[BS Select]Index over");
                }
            }
        }
    }
}