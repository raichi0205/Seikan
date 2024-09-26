using UnityEngine;
using System.Collections;
using Star.Character;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Guard", menuName = "Battle/Action/ActionGuard", order = 0)]
    public class ActionGuard : ActionBase
    {
        public override void Action(CharacterBase _target)
        {
            BattleSystem.Instance.SystemMsg = "身を守っている";
            base.Action(_target);
        }
    }
}