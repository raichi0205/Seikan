using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Common;
using Star.Battle.UI;
using Star.Character;

namespace Star.Battle
{
    public class ActionSelector : SingletonMonoBehaviour<ActionSelector>
    {
        [SerializeField] List<ActionSelectCellBase> actionSelectCellBases;

#if UNITY_EDITOR
        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.N))
        //    {
        //        Selected();
        //    }
        //    if (Input.GetKeyDown(KeyCode.M))
        //    {
        //        Selected(BattleSystem.TurnAction.SelectAction);
        //    }
        //}
#endif

        public void Initialize()
        {
            foreach(var cell in actionSelectCellBases)
            {
                cell.Initialize();
            }
        }

        /// <summary>
        /// 行動選択後の処理
        /// </summary>
        /// <param name="_turnAction"></param>
        public void Selected(BattleSystem.TurnAction _turnAction = BattleSystem.TurnAction.None)
        {
            if (BattleSystem.Instance.CurrentSelectData.Action.ActionType != ActionBase.Action_Type.Exhaust)
            {
                // 行動選択時カウントアップ
                Actor actor = BattleSystem.Instance.Actor;
                actor.SelectCounter++;
                actor.IsExhaust = true;
                actor.CurrentExhaust = 0;
                BattleSystem.Instance.NextTurnAction(BattleSystem.TurnAction.SelectAction);
                return;
            }

            // 次の行動へ進ませる
            BattleSystem.Instance.NextTurnAction(_turnAction);
        }
    }
}