using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Star.Battle;

namespace Star.Character
{
    [CreateAssetMenu(fileName = "Actor", menuName = "Battle/Character/ActorData", order = 0)]
    public class ActorData : CharacterData
    {
        [SerializeField] private int selectCountMax = 1;         // 一ターンで行動できる回数
        public int SelectCountMax { get { return selectCountMax; } }
        [SerializeField] private List<ActionSkill> defaultSkills = new List<ActionSkill>();
        public List<ActionSkill> DefaultSkills { get { return defaultSkills; } }
        
        [SerializeField] private List<ActionSkill> holdSkills = new List<ActionSkill>();
        public List<ActionSkill> HoldSkills { get { return holdSkills; } }

        public void Clone(ActorData _origin)
        {
            charaName = _origin.CharaName;
            status = (int[])_origin.status.Clone();
            selectCountMax = _origin.selectCountMax;
            defaultSkills.AddRange(_origin.defaultSkills);
            Debug.Log($"[Clone]skill:{defaultSkills.Count}");
        }
    }
}