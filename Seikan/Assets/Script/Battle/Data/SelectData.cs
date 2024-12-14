using UnityEngine;
using System.Collections.Generic;
using Star.Character;

namespace Star.Battle
{
    [System.Serializable]
    public class SelectData
    {
        [SerializeField] private ActionBase action;
        public ActionBase Action { get { return action; } set { action = value; } }
        [SerializeField] private CharacterBase executor = null;
        public CharacterBase Executor { get { return executor; } set { executor = value; } }

        [SerializeField] private List<CharacterBase> targets = new List<CharacterBase>();
        public List<CharacterBase> Targets { get { return targets; } set { targets = value; } }
        
    }
}