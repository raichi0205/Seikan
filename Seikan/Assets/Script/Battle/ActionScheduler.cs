using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Star.Character;

namespace Star.Battle
{
    public class ActionScheduler : MonoBehaviour
    {
        /// <summary>
        /// 選択行動実行
        /// </summary>
        private void Action()
        {

        }

        /// <summary>
        /// 行動順評価
        /// </summary>
        private List<ActionBase> ActionOrderEvaluation()
        {
            List<CharacterBase> actionOrderCharacters = new List<CharacterBase>();      // キャラクターの行動順を決める
            List<ActionBase> actions = new List<ActionBase>();
            foreach (CharacterBase chara in actionOrderCharacters)
            {
                // 行動の結合
                actions.AddRange(chara.Actions);
            }
            actions.Sort((a, b) => b.GetActionOrderRate() - a.GetActionOrderRate());        // レートの降順でソート         

            return actions;
        }
    }
}