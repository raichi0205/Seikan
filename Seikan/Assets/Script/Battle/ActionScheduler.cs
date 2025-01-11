using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Star.Character;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    public class ActionScheduler : MonoBehaviour
    {
        [SerializeField] List<SelectData> selectDatas = new List<SelectData>();
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
                // 実行者が死んでいないか
                if(await data.Executor.CheckHP())
                {
                    continue;
                }

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

                // エグゾーストを実行しない
                if (data.Action.GetType() != typeof(ActionExhaust))
                {
                    await data.Action.Action(data.Executor, data.Targets);
                }

                // 実行ごとに終了判定
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
#if UNITY_EDITOR
            string log = string.Empty;
            foreach(SelectData action in actions)
            {
                log += $"[Action:{action.Action.ActionType} Executor:{action.Executor.GetName()} Priority:{action.Action.GetActionOrderRate()}]\n";
            }
            Debug.Log($"[ActionScheduler]{log}");
#endif
            return actions;
        }

        /// <summary>
        /// 選択中のスキルの消費SP取得
        /// </summary>
        /// <returns></returns>
        public int GetSelectTotalSP()
        {
            int totalSp = 0;
            foreach(SelectData selectData in selectDatas)
            {
                totalSp += selectData.Action.GetCorrection(Status.SP).Value;
            }
            return totalSp;
        }

        /// <summary>
        /// 行動選択キャンセル
        /// </summary>
        public void Cancel()
        {
            selectDatas[^1].Action.Cancel();
            selectDatas.RemoveAt(selectDatas.Count - 1);
        }
    }
}