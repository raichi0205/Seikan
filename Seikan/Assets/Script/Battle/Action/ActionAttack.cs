using UnityEngine;
using System.Collections;
using Star.Character;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Battle/Action/ActionAttack", order = 0)]
    public class ActionAttack : ActionBase
    {
        public override void Action(CharacterBase _target)
        {
            BattleSystem.Instance.SystemMsg = $"に攻撃！";
            base.Action(_target);
        }
    }
}