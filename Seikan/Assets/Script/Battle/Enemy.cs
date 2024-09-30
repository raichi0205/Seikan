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
        public override void Initialize(CharacterData _characterData, int _num)
        {
            base.Initialize(_characterData, _num);
        }

        /// <summary>
        /// 行動決定
        /// </summary>
        /// <returns></returns>
        public async UniTask ActionThinking()
        {
            LuaSystem.Instance.StarLua(((EnemyData)characterData).ActionPatternScript);
            await LuaSystem.Instance.CurrentTask;

            EnemyLuaBridge.Instance.enemyNum = Num;
            LuaTable enemyClass = LuaSystem.Instance.LuaEnv.Global.Get<LuaTable>(characterData.name);
            Debug.Log($"[Enemy]{characterData.name}");
            LuaFunction thinkingFunc = enemyClass.Get<LuaFunction>("Thinking");
            thinkingFunc.Call(enemyClass);

            EnemyLuaBridge.Instance.enemyNum = int.MinValue;
        }
    }
}