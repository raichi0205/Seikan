using UnityEngine;
using System.Collections;

namespace Star.Battle
{
    public class StateDataBase : ScriptableObject
    {
        public enum Timing
        {
            None = 0,
            TurnStart,      // ターン開始時
            ActionAfter,    // 行動後
            TurnEnd,        // ターン終了時
        }

        [SerializeField] protected Sprite iconImage;                    // 状態アイコン
        [SerializeField] protected string stateName = "State Name";     // 状態名
        [SerializeField] protected int duration = 1;                    // 持続時間
        [SerializeField] protected Timing timing = Timing.TurnEnd;      // 発動タイミング
        public Timing ExeTiming { get { return timing; } }

        public virtual StateBase CreateState()
        {
            return null;
        }
    }
}