using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
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
            Chara = _executor;
            Target = _target;

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
        }

        /// <summary>
        /// エフェクト再生
        /// Luaで扱うのでコルーチンを返す
        /// </summary>
        /// <param name="_effectName">再生したいエフェクトの名前</param>
        /// <returns>コルーチン</returns>
        public IEnumerator PlayEffect(string _effectName)
        {
            return BattleSystem.Instance.EnemyManager.PlayEffect(Target.Num, _effectName).ToCoroutine();
        }

        /// <summary>
        /// 全敵キャラ取得
        /// 今作はプレイヤーの取得がないのでこれでいい
        /// </summary>
        /// <returns>敵キャラのリスト</returns>
        public List<Enemy> GetEnemies()
        {
            return BattleSystem.Instance.EnemyManager.Enemies;
        }

        public IEnumerator UpdateHPGage()
        {
            if (Target.Num >= 0)
            {
                return BattleSystem.Instance.EnemyManager.UpdateEnemyHPGage(Target.Num).ToCoroutine();
            }
            else if(Target.Num == -2)
            {
                BattleSystem system = BattleSystem.Instance;
                system.BattleUI.Footer.CharacterInfo.HPBar.UpdateValueText(Target.currentStatus[(int)Status.HP], Target.GetStatus(Status.HP));
                return system.BattleUI.Footer.CharacterInfo.HPBar.UpdateGage((float)Target.currentStatus[(int)Status.HP] / Target.GetStatus(Status.HP)).ToCoroutine();
            }
            return null;
        }

        public IEnumerator UpdateSPGage()
        {
            if (Target.Num >= -1)
            {
                BattleSystem system = BattleSystem.Instance;
                system.BattleUI.Footer.CharacterInfo.SPBar.UpdateValueText(Chara.currentStatus[(int)Status.SP], Chara.GetStatus(Status.SP));
                return system.BattleUI.Footer.CharacterInfo.SPBar.UpdateGage((float)Chara.currentStatus[(int)Status.SP] / Chara.GetStatus(Status.SP)).ToCoroutine();
            }
            // 仕様上ないから処理しない
            return null;
        }
    }
}