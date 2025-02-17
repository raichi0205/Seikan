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

        /// <summary>
        /// 体力チェック
        /// </summary>
        /// <returns></returns>
        public override async UniTask<bool> CheckHP()
        {
            if (currentStatus[(int)Status.HP] <= 0)
            {
                // Todo: 延命スキルがあるかチェックする
                // 無ければ死亡判定
                return true;
            }
            return false;
        }

        /// <summary>
        /// ゲージ更新処理
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        public override async UniTask UpdateGage(Status _status = Status.HP)
        {
            switch (_status)
            {
                case Status.HP:
                    await Battle.EnemyManager.Instance.UpdateEnemyHPGage(num);
                    break;
            }
        }
    }
}