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
            if (_executor.GetType() == typeof(Actor))
            {
                Actor actor = (Actor)_executor;
                Executor = actor;
                // エグゾーストを有効に
                actor.IsExhaust = true;
                actor.CurrentExhaust = 0;
                // エグゾーストの表記更新
                BattleSystem.Instance.BattleUIController.UpdateExhaustActive();
            }
        }

        public override void Cancel()
        {
            if (Executor.GetType() == typeof(Actor))
            {
                Actor actor = (Actor)Executor;
                // エグゾーストを有効に
                actor.IsExhaust = false;
                actor.CurrentExhaust = 100;
                // エグゾーストの表記更新
                BattleSystem.Instance.BattleUIController.UpdateExhaustActive();

            }
        }

        public void Clone(ActionExhaust _actionExhaust)
        {
            base.Clone(_actionExhaust);
        }
    }
}