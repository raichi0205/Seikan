using UnityEngine;
using System.Collections;
using Cysharp.Threading.Tasks;
using Star.Lua;
using System;
using XLua;

namespace Star.Character
{
    [System.Serializable]
    public class Enemy : CharacterBase
    {
        // 自分の対象番号
        [SerializeField] int num = int.MinValue;
        public int Num { get { return num; } }      

        public void Initialize(CharacterData _characterData, int _num)
        {
            num = _num;
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

            EnemyLuaBridge.Instance.Enemy = this;
            LuaTable enemyClass = LuaSystem.Instance.LuaEnv.Global.Get<LuaTable>(characterData.name);
            Debug.Log($"[Enemy]{characterData.name}");
            LuaFunction thinkingFunc = enemyClass.Get<LuaFunction>("Thinking");
            thinkingFunc.Call(enemyClass);

            EnemyLuaBridge.Instance.Enemy = null;
        }
    }
}