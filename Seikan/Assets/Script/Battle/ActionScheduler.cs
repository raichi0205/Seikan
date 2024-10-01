using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Star.Character;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    public class ActionScheduler : MonoBehaviour
    {
        /// <summary>
        /// 選択行動実行
        /// </summary>
        public async UniTask Action()
        {
            // 順番を評価し、その順で攻撃を行う
            List<SelectData> selectDatas = ActionOrderEvaluation();
            foreach(SelectData data in selectDatas)
            {
                 await BattleSystem.Instance.ActionExecute(data);
            }

            // ToDo: 演出が終わってから次の行動へ移る
            BattleSystem.Instance.NextTurnAction();
        }

        /// <summary>
        /// 行動順評価
        /// </summary>
        private List<SelectData> ActionOrderEvaluation()
        {
            List<SelectData> actions = BattleSystem.Instance.SelectDatas;
            actions.Sort((a, b) => b.Action.GetActionOrderRate() - a.Action.GetActionOrderRate());        // レートの降順でソート
            return actions;
        }
    }
}