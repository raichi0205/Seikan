using UnityEngine;
using System.Collections;
using Star.Battle;
using System.Collections.Generic;

namespace Star.Character
{
    public class CharacterBase
    {
        [SerializeField] CharacterData characterData;
        public List<StateBase> States = new List<StateBase>();      // 現在の状態リスト
        public List<ActionBase> Actions = new List<ActionBase>();   // 行動のリスト

        /// <summary>
        /// 状態の更新
        /// </summary>
        public void UpdateStatus()
        {
            foreach (StateBase state in States)
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
            return characterData.status[(int)_statusType];
        }
    }
}