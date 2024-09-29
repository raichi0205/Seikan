using UnityEngine;
using System.Collections;
using Cysharp.Threading.Tasks;
using Star.Lua;
using System;
using XLua;

namespace Star.Character
{
    public class Enemy : CharacterBase
    {
        public override void Initialize(CharacterData _characterData)
        {
            base.Initialize(_characterData);
        }

        /// <summary>
        /// 行動決定
        /// </summary>
        /// <returns></returns>
        public async UniTask ActionThinking()
        {
            LuaSystem.Instance.StarLua(((EnemyData)characterData).ActionPatternScript);
            await LuaSystem.Instance.CurrentTask;
            LuaTable enemyClass = LuaSystem.Instance.LuaEnv.Global.Get<LuaTable>(characterData.name);
            Debug.Log($"[Enemy]{characterData.name}");
            Action action = enemyClass.Get<Action>("Thinking");
            action.Invoke();
        }
    }
}