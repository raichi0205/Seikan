using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Star.Character;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    public class ActionScheduler : MonoBehaviour
    {
        List<SelectData> selectDatas = new List<SelectData>();
        public List<SelectData> SelectDatas { get { return selectDatas; } }

        /// <summary>
        /// 選択行動実行
        /// </summary>
        public async UniTask Action()
        {
            // 順番を評価し、その順で攻撃を行う
            List<SelectData> selectDatas = ActionOrderEvaluation();
            foreach(SelectData data in selectDatas)
            {
                // 単体目標の時の処理
                if (data.Targets.Count > 0)
                {
                    // 目標が敵の場合
                    if (data.Targets[0].GetType() == typeof(Enemy))
                    {
                        // 死亡判定
                        if (await data.Targets[0].CheckHP())
                        {
                            // フィールド上に他の敵が残ってる
                            if(EnemyManager.Instance.FieldEnemies.Count > 0)
                            {
                                data.Targets[0] = EnemyManager.Instance.FieldEnemies[0];
                            }
                        }
                    }
                }
                await data.Action.Action(data.Executor, data.Targets);

                // 攻撃ごとに終了判定
                if(!await BattleSystem.Instance.EndJudge(false))
                {
                    // 継続されない場合処理を抜ける
                    break;
                }
            }
        }

        /// <summary>
        /// 行動順評価
        /// </summary>
        private List<SelectData> ActionOrderEvaluation()
        {
            List<SelectData> actions = selectDatas;
            actions.Sort((a, b) => b.Action.GetActionOrderRate() - a.Action.GetActionOrderRate());        // レートの降順でソート
            return actions;
        }
    }
}