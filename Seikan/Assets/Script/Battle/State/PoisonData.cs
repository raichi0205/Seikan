using UnityEngine;
using System.Collections;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Poison", menuName = "Battle/State", order = 0)]
    public class PoisonData : StateDataBase
    {
        [SerializeField] float decreaseRate = 0.1f;
        public float DecreaseRate { get { return decreaseRate; } }

        /// <summary>
        /// 状態を作成する
        /// </summary>
        /// <returns></returns>
        public override StateBase CreateState()
        {
            PoisonState state = new PoisonState();
            state.PoisonData = this;
            return state;
        }
    }
}