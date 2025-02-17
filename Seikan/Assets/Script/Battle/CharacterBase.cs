using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Editor;
using Cysharp.Threading.Tasks;
using Star.Battle;

namespace Star.Character
{
    [System.Serializable]
    public class CharacterBase
    {
        [SerializeField] protected CharacterData characterData;
        [SerializeField, NamedArray(typeof(Status))] public int[] currentStatus = new int[(int)Status.NUM];     // 現在のステータス値
        public Dictionary<StateDataBase.Timing, List<StateBase>> States = new Dictionary<StateDataBase.Timing, List<StateBase>>();  // 現在の状態一覧
#if UNITY_EDITOR
        [SerializeField] List<StateBase> debugStatesTS = new List<StateBase>();
        [SerializeField] List<StateBase> debugStatesAA = new List<StateBase>();
        [SerializeField] List<StateBase> debugStatesTE = new List<StateBase>();
#endif

        public virtual void Initialize(CharacterData _characterData)
        {
            characterData = _characterData;
            System.Array.Copy(_characterData.status, currentStatus, _characterData.status.Length);

            // 状態情報の辞書作成
            States.Add(StateDataBase.Timing.TurnStart, new List<StateBase>());
            States.Add(StateDataBase.Timing.ActionAfter, new List<StateBase>());
            States.Add(StateDataBase.Timing.TurnEnd, new List<StateBase>());
#if UNITY_EDITOR
            debugStatesTS = States[StateDataBase.Timing.TurnStart];
            debugStatesAA = States[StateDataBase.Timing.ActionAfter];
            debugStatesTE = States[StateDataBase.Timing.TurnEnd];
#endif
        }

        public async virtual UniTask<bool> CheckHP()
        {
            return false;
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

        /// <summary>
        /// 状態付与
        /// </summary>
        /// <param name="_stateName"></param>
        /// <returns></returns>
        public async UniTask GrantState(string _stateName)
        {
            StateBase state = StateManager.Instance.GetState(_stateName);
            if(state != null)
            {
                States[state.StateData.ExeTiming].Add(state);
            }
            else
            {
                Debug.LogError($"[State] 状態の取得に失敗しました");
            }
        }

        /// <summary>
        /// 状態の実行
        /// </summary>
        /// <param name="_timing"></param>
        public async UniTask ExecuteState(StateDataBase.Timing _timing)
        {
            List<StateBase> states = new List<StateBase>();
            foreach(StateBase state in States[_timing])
            {
                await state.Execute(this);
                if (!state.UpdateState())
                {
                    states.Add(state);
                }
            }

            foreach(StateBase state in states)
            {
                States[_timing].Remove(state);
            }
        }

        /// <summary>
        /// ゲージの更新処理
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        public virtual async UniTask UpdateGage(Character.Status _status)
        {

        }
    }
}