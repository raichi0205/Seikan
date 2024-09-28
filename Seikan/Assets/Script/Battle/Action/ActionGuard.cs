using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Guard", menuName = "Battle/Action/ActionGuard", order = 0)]
    public class ActionGuard : ActionBase
    {
        public override async UniTask Action(CharacterBase _target)
        {
            BattleSystem.Instance.SystemMsg = "身を守っている";
            base.Action(_target);
        }
    }
}