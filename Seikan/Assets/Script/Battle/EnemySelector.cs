using UnityEngine;
using System.Collections;

namespace Star.Battle
{
    public class EnemySelector
    {
        private int stackIndex = int.MinValue;       // -1は全体選択

        /// <summary>
        /// 選択内容
        /// </summary>
        /// <param name="_index"></param>
        public void SetSelectIndex(int _index)
        {
            stackIndex = _index;
        }

        /// <summary>
        /// 選択解除
        /// </summary>
        public void ResetSelectIndex()
        {
            stackIndex = int.MinValue;
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        public void EnterSelectIndex()
        {
            BattleSystem.Instance.CurrentSelectData.Target = stackIndex;        // 選択した番号を記録
            BattleSystem.Instance.NextTurnAction();
        }
    }
}