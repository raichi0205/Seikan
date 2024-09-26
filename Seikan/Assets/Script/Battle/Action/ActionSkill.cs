using UnityEngine;
using System.Collections;
using Star.Character;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Battle/Action/ActionSkill", order = 0)]
    public class ActionSkill : ActionBase
    {
        public override void Action(CharacterBase _target)
        {
            // ToDo: Luaで処理するとかいろいろ
            base.Action(_target);
        }
    }
}