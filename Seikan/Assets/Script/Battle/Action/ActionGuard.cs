using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Guard", menuName = "Battle/Action/ActionGuard", order = 0)]
    public class ActionGuard : ActionBase
    {
        int delayTime = 1000;

        public override async UniTask Action(CharacterBase _executor, CharacterBase _target)
        {
            BattleSystem.Instance.SystemMsg = "身を守っている";
            _executor.AddCurrentStatus(Status.DEF, corrections[(int)Status.DEF].Value);
            _executor.MultiCurrentStatus(Status.DEF, corrections[(int)Status.DEF].Rate);
            base.Action(_executor, _target);

            await UniTask.Delay(delayTime);
        }
    }
}