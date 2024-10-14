using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using Star.Character;
using Star.Lua;

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

        public override async UniTask Action(CharacterBase _executor, CharacterBase _target)
        {
            CurrentSkill = this;
            target = _target;

            // Luaの呼出
            if (!string.IsNullOrEmpty(luaScript))
            {
                LuaSystem.Instance.StarLua(luaScript);
            }

            // 読み込み待機が必要な場合待つ
            await LuaSystem.Instance.CurrentTask;

            XLua.LuaTable skillClass = LuaSystem.Instance.LuaEnv.Global.Get<XLua.LuaTable>(name);
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
            base.Action(_executor, _target);
        }

        public Effekseer.EffekseerEmitter PlayEffect(Vector3 _pos, string _name)
        {
            Transform parent = BattleSystem.Instance.EnemyManager.GetEnemyTransform(target.Num);
            return Effect.EffectSystem.Instance.Play(_pos, _name, parent);
        }
    }
}