using UnityEngine;
using System.Collections.Generic;
using Star.Common;

namespace Star.Battle
{
    public class StateManager : SingletonMonoBehaviour<StateManager>
    {
        [SerializeField] List<StateDataBase> states;

        /// <summary>
        /// 指定の状態を取得する
        /// </summary>
        /// <param name="_stateName"></param>
        /// <returns></returns>
        public StateBase GetState(string _stateName)
        {
            foreach(StateDataBase stateData in states)
            {
                if(stateData.name == _stateName)
                {
                    return stateData.CreateState();
                }
            }
            Debug.LogError($"[State] 指定された状態情報が見つかりません:{_stateName}");
            return null;
        }
    }
}