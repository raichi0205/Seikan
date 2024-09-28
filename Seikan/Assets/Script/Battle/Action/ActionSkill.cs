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
        [SerializeField] string skillName = string.Empty;
        public string SkillName { get { return skillName; } }
        [SerializeField] string luaScript = string.Empty;
        public override async UniTask Action(CharacterBase _target)
        {
            // Luaの呼出
            if (!string.IsNullOrEmpty(luaScript))
            {
                LuaSystem.Instance.StarLua(luaScript);
            }

            // 読み込み待機が必要な場合待つ
            await LuaSystem.Instance.CurrentTask;

            XLua.LuaTable skillClass = LuaSystem.Instance.LuaEnv.Global.Get<XLua.LuaTable>(name);
            Action action = skillClass.Get<Action>($"Action");
            if (action != null)
            {
                Debug.Log($"[Skill] action");
                action.Invoke();
            }
            else
            {
                Debug.LogError($"[Skill] NULL ACTION:{name}.Action");
            }
            base.Action(_target);
        }
    }
}