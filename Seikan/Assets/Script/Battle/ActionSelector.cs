using UnityEngine;
using System.Collections;
using Star.Common;

namespace Star.Battle
{
    public class ActionSelector : SingletonMonoBehaviour<ActionSelector>
    {
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                Selected();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                Selected(BattleSystem.TurnAction.SelectAction);
            }
        }
#endif

        /// <summary>
        /// 行動選択後の処理
        /// </summary>
        /// <param name="_turnAction"></param>
        public virtual void Selected(BattleSystem.TurnAction _turnAction = BattleSystem.TurnAction.None)
        {
            // 次の行動へ進ませる
            BattleSystem.Instance.MainSystem(_turnAction);
        }
    }
}