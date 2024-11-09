using UnityEngine;
using System.Collections;
using Star.Character;
using Cysharp.Threading.Tasks;
using Star.Effect;
using Effekseer;
using DG.Tweening;
using Star.Sound;
using System.Collections.Generic;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Attack", menuName = "Battle/Action/ActionAttack", order = 0)]
    public class ActionAttack : ActionBase
    {
        AudioSource attackSound = null;

        public override async UniTask Action(CharacterBase _executor, List<CharacterBase> _target)
        {
            BattleSystem system = BattleSystem.Instance;
            Targets = _target;

            foreach (CharacterBase target in _target)
            {
                // ターゲットが死亡しているか
                if (target.currentStatus[(int)Status.HP] <= 0)
                {
                    return;
                }

                system.SystemMsg = $"{target.GetName()}に攻撃！";

                // ダメージ処理
                int def = target.GetCurrentStatus(Status.DEF);
                int damage = _executor.GetCurrentStatus(Status.ATK) - def;
                if (damage < 0)
                {
                    damage = 1;
                }
                target.SubCurrentStatus(Status.HP, damage);

                if (target.Num >= 0)
                {
                    Transform parent = BattleSystem.Instance.EnemyManager.GetEnemyTransform(target.Num);
                    //EffekseerEmitter emitter = EffectSystem.Instance.Play(Vector3.zero, "Laser01", parent);
                    //await EffectSystem.Instance.EndDelay(emitter);
                    await system.EnemyManager.PlayEffect(target.Num, "Attack_01");
                    await system.EnemyManager.UpdateEnemyHPGage(target.Num);
                }
                else if (target.Num == -2)
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
                    await system.BattleUI.Footer.CharacterInfo.HPBar.UpdateGage((float)target.currentStatus[(int)Status.HP] / target.GetStatus(Status.HP));
                    system.BattleUI.Footer.CharacterInfo.HPBar.UpdateValueText(target.currentStatus[(int)Status.HP], target.GetStatus(Status.HP));
                }
                system.SystemMsg = $"";
                await UniTask.Delay(200);
                system.SystemMsg = $"{damage}ダメージ与えた";
                await UniTask.Delay(500);
                return;
            }
        }
    }
}