using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Exhaust", menuName = "Battle/Action/ActionExhaust", order = 0)]
    public class ActionExhaust : ActionBase
    {
        public override async UniTask Action(CharacterBase _executor, List<CharacterBase> _character = null)
        {
            // 発動者が指定先になる
            // エグゾーストを有効に

            base.Action(_executor, _character);
        }
        public void Clone(ActionExhaust _actionExhaust)
        {
            base.Clone(_actionExhaust);
        }
    }
}