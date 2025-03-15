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
        [SerializeField] protected string duplicatesGroupID = "empty";  // 重複効果のグループ分けID
        [SerializeField] protected int duration = 1;                    // 持続時間
        [SerializeField] protected Timing timing = Timing.TurnEnd;      // 発動タイミング
        [SerializeField] protected int duplicates = 0;                  // 重複回数
        [SerializeField] protected string infotext = "情報";            // 状態の内容
        public Sprite IconImage { get { return iconImage; } }
        public string StateName { get { return stateName; } }
        public string DuplicatesGroupID { get { return duplicatesGroupID; } }
        public int Duration { get { return duration; } }
        public Timing ExeTiming { get { return timing; } }
        public int Duplicates { get { return duplicates; } }
        public string InfoText { get { return infotext; } }

        public virtual StateBase CreateState()
        {
            return null;
        }
    }
}