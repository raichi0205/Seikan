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
        [SerializeField]
        int turn = 0;           // 現在のターン

        [SerializeField]
        BattleUI battleUI;      // 戦闘画面UI

        ActionScheduler actionScheduler = new ActionScheduler();
        List<UnityAction> schedule = new List<UnityAction>();
        public TurnAction turnAction = TurnAction.None;

        /// <summary>
        /// システムメッセージ
        /// </summary>
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

        Actor actor = new Actor();                  // 主人公
        List<Enemy> enemies = new List<Enemy>();    // 敵

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
            battleUI.Initialize();

            schedule.Add(TurnStart);
            schedule.Add(SelectAction);
            schedule.Add(SelectEnemy);
            schedule.Add(ActionTurn);
            schedule.Add(TurnEnd);

            ActionSelector.Instance.Initialize();

            MainSystem();
        }

        public void MainSystem(TurnAction _designationAction = TurnAction.None)
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
            if(turn < maxTurn)
            { 
                turn++;     // ターンを一つ繰り上げる
                // Todo: ターン開始時の演出
                // プレイヤーの状態の更新
                actor.UpdateStatus();
                // 敵の状態の更新
                foreach(var enemy in enemies)
                {
                    enemy.UpdateStatus();
                }

                MainSystem();
            }
            else
            {
                // 規定ターン数をオーバー、戦闘終了 敗北扱い
            }
        }

        private void SelectAction()
        {
            Debug.Log("[BattleSystem] SelectAction");
            battleUI.OpenActionSelectWindow();
        }

        private void SelectEnemy()
        {
            Debug.Log("[BattleSystem] SelectEnemy");
            battleUI.CloseActionSelectWindow();
        }

        private void ActionTurn()
        {
            Debug.Log("[BattleSystem] ActionTurn");
        }

        private void TurnEnd()
        {
            Debug.Log("[BattleSystem] TurnEnd");
        }
    }
}