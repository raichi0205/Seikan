using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Star.Character
{
    [CreateAssetMenu(fileName = "Actor", menuName = "Battle/Character/ActorData", order = 0)]
    public class ActorData : CharacterData
    {
        [SerializeField] private int selectCountMax = 1;         // 一ターンで行動できる回数
        public int SelectCountMax { get { return selectCountMax; } }
    }
}