using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Star.Character
{
    /// <summary>
    /// キャラクターの状態ベース
    /// </summary>
    public class StateBase : ScriptableObject
    {
        public enum Timing
        {
            None = 0,
            TurnStart,      // ターン開始時
            ActionAfter,    // 行動後
            TurnEnd,        // ターン終了時
        }

        protected string stateName = "None";    // 状態名
        public string StateName { get { return stateName; } }
        protected Sprite stateIcon = null;      // 状態アイコン
        public Sprite StateIcon { get { return stateIcon; } }
        protected int stateTurn = -1;           // このステートの継続期間。-1は無限
        public int StateTurn { get { return stateTurn; } }
        protected Timing timing = Timing.None;
        public Timing StateTiming { get { return timing; } }

        /// <summary>
        /// 状態の更新処理
        /// </summary>
        /// <returns>false:状態の終了 true:状態の継続</returns>
        public virtual bool UpdateState()
        {
            // 継続期間のカウントを進める
            stateTurn -= stateTurn < 0 ? 0 : 1;
            
            // カウント0の場合状態終了
            if(stateTurn == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 状態の発動
        /// </summary>
        public virtual void Activation()
        {
            Debug.Log("[State] Activation");
        }

        public void StateEnd()
        {

        }

        /// <summary>
        /// 状態終了時の処理
        /// </summary>
        public void OnDestroy()
        {
            
        }
    }
}