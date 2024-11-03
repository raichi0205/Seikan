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

        /// <summary>
        /// エフェクト再生
        /// Luaで扱うのでコルーチンを返す
        /// </summary>
        /// <param name="_effectName">再生したいエフェクトの名前</param>
        /// <returns>コルーチン</returns>
        public IEnumerator PlayEffect(string _effectName)
        {
            return BattleSystem.Instance.EnemyManager.PlayEffect(target.Num, _effectName).ToCoroutine();
        }
    }
}