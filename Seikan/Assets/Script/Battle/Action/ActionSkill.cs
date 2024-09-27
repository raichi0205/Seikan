using UnityEngine;
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
        public override void Action(CharacterBase _target)
        {
            // Luaの呼出
            if (!string.IsNullOrEmpty(luaScript))
            {
                LuaSystem.Instance.StarLua(luaScript);
            }

            // ToDo: Lua実行完了を待つ

            base.Action(_target);
        }
    }
}