using UnityEngine;
using System.Collections;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    [System.Serializable]
    public class StateBase
    {
        protected int duration = 1;         // 持続期間
        public int Duration { get { return duration; } }
        protected int elapsed = 0;          // 経過期間
        protected StateDataBase stateData;  // 状態の元データ
        public StateDataBase StateData
        {
            get { return stateData; }
            set { stateData = value; }
        }     

        public async virtual UniTask Execute(Character.CharacterBase _exeChara)
        {
            
        }

        /// <summary>
        /// 状態の取得
        /// </summary>
        /// <returns></returns>
        public virtual bool UpdateState()
        {
            elapsed++;
            return elapsed < duration;
        }
    }
}