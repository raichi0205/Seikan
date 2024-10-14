using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;
using Star.Effect;
using Effekseer;
using DG.Tweening;
using Star.Sound;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Battle/Action/ActionAttack", order = 0)]
    public class ActionAttack : ActionBase
    {
        AudioSource attackSound = null;

        public override async UniTask Action(CharacterBase _executor, CharacterBase _target)
        {
            BattleSystem.Instance.SystemMsg = $"{_target}に攻撃！";
            base.Action(_executor, _target);
            if (_target.Num >= 0)
            {
                Transform parent = BattleSystem.Instance.EnemyManager.GetEnemyTransform(_target.Num);
                EffekseerEmitter emitter = EffectSystem.Instance.Play(Vector3.zero, "Laser01", parent);
                await EffectSystem.Instance.EndDelay(emitter);              
            }
            else if (_target.Num == -2)
            {
                if (attackSound == null)
                {
                    attackSound = SoundManager.Instance.Play(SoundManager.MixerGroup.SE, "Attack");
                }
                else
                {
                    attackSound.Play();
                }
                RectTransform rect = (RectTransform)BattleSystem.Instance.BattleUI.ShakeArea.transform;
                await rect.DOShakePosition(1, 100).AsyncWaitForCompletion();
            }

            // ダメージ処理
            int def = _target.GetCurrentStatus(Status.DEF);
            int damage = _executor.GetCurrentStatus(Status.ATK) - def;
            if (damage < 0)
            {
                damage = 1;
            }
            _target.SubCurrentStatus(Status.HP, damage);
            BattleSystem.Instance.SystemMsg = $"{damage}ダメージ与えた";
        }
    }
}