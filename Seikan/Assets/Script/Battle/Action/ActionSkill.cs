using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Star.Character;
using Star.Lua;
using DG.Tweening;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Battle/Action/ActionSkill", order = 0)]
    public class ActionSkill : ActionBase
    {
        public static ActionSkill CurrentSkill = null;

        [SerializeField] string skillName = string.Empty;
        public string SkillName { get { return skillName; } }
        [SerializeField] string luaScript = string.Empty;
        public bool IsEnd = false;
        [SerializeField] bool useExhaust = false;
        public bool UseExhaust { get { return useExhaust; } }
        [SerializeField] int sortPriority = 0;      // ソート用
        public int SortPriority { get { return sortPriority; } }

        public override async UniTask Action(CharacterBase _executor, List<CharacterBase> _target)
        {
            CurrentSkill = this;
            Executor = _executor;
            Targets = new List<CharacterBase>();
            
            foreach (CharacterBase target in _target)
            {
                // ターゲットが死亡していないか
                if (target.currentStatus[(int)Status.HP] > 0)
                {
                    // 死亡していなければターゲットとして登録
                    Targets.Add(target);
                }
            }

            if(Targets.Count == 0)
            {
                // 目標がいなければ終了
                return;
            }

            // Luaの呼出
            if (!string.IsNullOrEmpty(luaScript))
            {
                LuaSystem.Instance.StarLua(luaScript);
            }
            else
            {
                Debug.LogError($"[Skill] Luaの実行がされませんでした。{luaScript}");
                return;
            }

            // 読み込み待機が必要な場合待つ
            await LuaSystem.Instance.CurrentTask;

            XLua.LuaTable skillClass = LuaSystem.Instance.LuaEnv.Global.Get<XLua.LuaTable>(name);
            if(skillClass == null)
            {
                Debug.LogError($"[Skill] Script Error null {name}");
                return;
            }
            XLuaGenConfig.LuaCoroutine action = skillClass.Get<XLuaGenConfig.LuaCoroutine>($"Action");
            if (action != null)
            {
                Debug.Log($"[Skill] action");
                action.Invoke();
                await UniTask.WaitUntil(() => IsEnd);
                CurrentSkill = null;
                IsEnd = false;
                Debug.Log($"[Skill] End action");
            }
            else
            {
                Debug.LogError($"[Skill] NULL ACTION:{name}.Action");
            }
        }

        /// <summary>
        /// エフェクト再生
        /// Luaで扱うのでコルーチンを返す
        /// </summary>
        /// <param name="_effectName">再生したいエフェクトの名前</param>
        /// <returns>コルーチン</returns>
        public IEnumerator PlayEffect(string _effectName, int _targetNum)
        {
            if (_targetNum >= 0)
            {
                return EnemyManager.Instance.PlayEffect(_targetNum, _effectName).ToCoroutine();
            }
            else
            {
                // 全体エフェクトの再生
                var effect = BattleSystem.Instance.BattleUIController.AllEffect;
                Effect.SpriteEffectManager.Instance.SetEffect(_effectName, effect);
                effect.Play();
                return effect.EndDelay().ToCoroutine();
            }
        }

        public void PlayShake()
        {
            RectTransform rect = (RectTransform)BattleSystem.Instance.BattleUIController.ShakeArea.transform;
            rect.DOShakePosition(1, 100).WaitForCompletion();
        }

        /// <summary>
        /// 全敵キャラ取得
        /// 今作はプレイヤーの取得がないのでこれでいい
        /// </summary>
        /// <returns>敵キャラのリスト</returns>
        public List<Enemy> GetEnemies()
        {
            return EnemyManager.Instance.Enemies;
        }

        public IEnumerator UpdateHPGage(CharacterBase _target)
        {
            if (typeof(Enemy) == _target.GetType())
            {
                return EnemyManager.Instance.UpdateEnemyHPGage(((Enemy)_target).Num).ToCoroutine();
            }
            else if(typeof(Actor) == _target.GetType())
            {
                BattleSystem system = BattleSystem.Instance;
                system.BattleUIController.Footer.CharacterInfo.HPBar.UpdateValueText(system.Actor.currentStatus[(int)Status.HP], system.Actor.GetStatus(Status.HP));
                return system.BattleUIController.Footer.CharacterInfo.HPBar.UpdateGage((float)system.Actor.currentStatus[(int)Status.HP] / system.Actor.GetStatus(Status.HP)).ToCoroutine();
            }
            return null;
        }

        public IEnumerator UpdateSPGage(CharacterBase _target = null)
        {
            if (_target == null || typeof(Actor) == _target.GetType())
            {
                BattleSystem system = BattleSystem.Instance;
                system.BattleUIController.Footer.CharacterInfo.SPBar.UpdateValueText(Executor.currentStatus[(int)Status.SP], Executor.GetStatus(Status.SP));
                return system.BattleUIController.Footer.CharacterInfo.SPBar.UpdateGage((float)Executor.currentStatus[(int)Status.SP] / Executor.GetStatus(Status.SP)).ToCoroutine();
            }
            // 仕様上ないから処理しない
            return null;
        }

        public void Clone(ActionSkill _actionSkill)
        {
            skillName = _actionSkill.skillName;
            luaScript = _actionSkill.luaScript;
            useExhaust = _actionSkill.useExhaust;
            base.Clone(_actionSkill);
        }

        public override void Cancel()
        {
            // エグゾースト使用しているか
            if (usedExhaust)
            {
                // 使用している場合戻す
                BattleSystem.Instance.Actor.IsExhaust = true;
                BattleSystem.Instance.Actor.CurrentExhaust = 100;
            }
            base.Cancel();
        }
    }
}