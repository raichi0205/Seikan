using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Escape", menuName = "Battle/Action/ActionEscape", order = 0)]
    public class ActionEscape : ActionBase
    {
        public override async UniTask Action(CharacterBase _executor, List<CharacterBase> _target)
        {
            base.Action(_executor, _target);
            // Todo: 逃走可否の仕組みづくりを行う
            BattleSystem.Instance.SystemMsg = $"逃げられない";
        }

        public void Clone(ActionEscape _actionEscape)
        {
            base.Clone(_actionEscape);
        }
    }
}