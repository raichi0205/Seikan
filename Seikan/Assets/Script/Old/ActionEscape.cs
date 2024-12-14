using UnityEngine;
using System.Collections;
using Star.Old.Character;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Star.Old.Battle
{
    //[CreateAssetMenu(fileName = "Escape", menuName = "Battle/Action/ActionEscape", order = 0)]
    public class ActionEscape : ActionBase
    {
        public override async UniTask Action(CharacterBase _executor, List<CharacterBase> _target)
        {
            base.Action(_executor, _target);
        }
    }
}