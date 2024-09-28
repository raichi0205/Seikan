using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Battle/Action/ActionAttack", order = 0)]
    public class ActionAttack : ActionBase
    {
        public override async UniTask Action(CharacterBase _target)
        {
            BattleSystem.Instance.SystemMsg = $"に攻撃！";
            base.Action(_target);
        }
    }
}