using UnityEngine;
using System.Collections;
using Star.Battle;
using System.Collections.Generic;
using Star.Editor;

namespace Star.Character
{
    [System.Serializable]
    public class CharacterBase
    {
        [SerializeField] protected CharacterData characterData;
        [SerializeField, NamedArray(typeof(Status))] public int[] currentStatus = new int[(int)Character.Status.NUM];   // 現在のステータス値
        public List<StateBase> States = new List<StateBase>();      // 現在の状態リスト
        public List<ActionBase> Actions = new List<ActionBase>();   // 行動のリスト
        public int Num = int.MinValue;      // 自分の対象番号

        public virtual void Initialize(CharacterData _characterData, int _num)
        {
            Num = _num;
            characterData = _characterData;
            System.Array.Copy(_characterData.status, currentStatus, _characterData.status.Length);
        }

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

        public string GetName()
        {
            return characterData.CharaName;
        }

        public int GetCurrentStatus(Status _statusType)
        {
            return currentStatus[(int)_statusType];
        }

        public void SetCurrentStatus(Status _statusType, int _value)
        {
            currentStatus[(int)_statusType] = _value;
        }

        public void AddCurrentStatus(Status _statusType, int _value)
        {
            currentStatus[(int)_statusType] += _value;
        }

        public void SubCurrentStatus(Status _statusType, int _value)
        {
            currentStatus[(int)_statusType] -= _value;
        }

        public void MultiCurrentStatus(Status _statusType, float _value)
        {
            currentStatus[(int)_statusType] = Mathf.RoundToInt(currentStatus[(int)_statusType] * _value);
        }
    }
}