using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Star.Battle;

namespace Star.Character
{
    public enum Status
    {
        HP,
        MP,
        ATK,
        DEF,
        AGI,
        LUK,
        NUM
    }

    public class CharacterData
    {
        protected int[] status = new int[(int)Character.Status.NUM];          // ステータス地

        public List<StateBase> States = new List<StateBase>();      // 現在の状態リスト
        public List<ActionBase> Actions = new List<ActionBase>();   // 行動のリスト

        /// <summary>
        /// 状態の更新
        /// </summary>
        public void UpdateStatus()
        {
            foreach(StateBase state in States)
            {
                if (state.UpdateState())
                {
                    state.StateEnd();           // 状態の終了
                    States.Remove(state);       // 状態の削除
                }
            }
        }

        public int GetStatus(Status _statusType)
        {
            return status[(int)_statusType];
        }
    }
}