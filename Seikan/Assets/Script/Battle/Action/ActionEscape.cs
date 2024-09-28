using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Escape", menuName = "Battle/Action/ActionEscape", order = 0)]
    public class ActionEscape : ActionBase
    {
        public override async UniTask Action(CharacterBase _target)
        {
            base.Action(_target);
        }
    }
}