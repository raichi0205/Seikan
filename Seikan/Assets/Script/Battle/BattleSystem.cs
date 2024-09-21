using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Star.Common;
using Star.Character;

namespace Star.Battle
{
    public class BattleSystem : SingletonMonoBehaviour<BattleSystem>
    {
        public enum TurnAction
        {
            None = -1,
            TurnStart,
            SelectAction,
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

        public void Initialize()
        {
            schedule.Add(TurnStart);
            schedule.Add(SelectAction);

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
        }
    }
}