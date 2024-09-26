using UnityEngine;
using System.Collections;
using Star.Character;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Escape", menuName = "Battle/Action/ActionEscape", order = 0)]
    public class ActionEscape : ActionBase
    {
        public override void Action(CharacterBase _target)
        {
            base.Action(_target);
        }
    }
}