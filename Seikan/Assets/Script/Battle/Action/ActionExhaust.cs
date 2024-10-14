using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Exhaust", menuName = "Battle/Action/ActionExhaust", order = 0)]
    public class ActionExhaust : ActionBase
    {
        public override async UniTask Action(CharacterBase _executor, CharacterBase _character = null)
        {
            // 発動者が指定先になる
            _character = Chara;
            // エグゾーストを有効に

            base.Action(_executor, _character);
        }
    }
}