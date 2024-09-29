using UnityEngine;
using System.Collections;
using Star.Common;
using Star.Battle;
using System;

namespace Star.Character {
    public class EnemyLuaBridge : Singleton<EnemyLuaBridge>
    {
        public Enemy CurrentEnemy = null;

        public void SelectAction(string _select)
        {
            Debug.Log($"[Enemy][Select]{_select}");
            EnemyManager enemyManager = BattleSystem.Instance.EnemyManager;
            ActionBase.Action_Type action_Type;

            string[] select = _select.Split('/');       // 選択内容/スキル名

            SelectData selectData = new SelectData();
            if (Enum.TryParse(select[0], out action_Type))
            {
                switch (action_Type)
                {
                    case ActionBase.Action_Type.Attack:
                        selectData.Action = enemyManager.ActionAttack;
                        selectData.Target = -2;     // 主人公相手に攻撃するので-2
                        break;
                    case ActionBase.Action_Type.Guard:
                        selectData.Action = enemyManager.ActionGuard;
                        selectData.Target = CurrentEnemy.Num;       // 自分への行動
                        break;
                    case ActionBase.Action_Type.Skill:
                        ActionSkill skill = SerachActionSkill(select[1]);
                        if(skill != null)
                        {
                            selectData.Action = skill;
                            selectData.Target = skill.DefaultTargetNum;
                        }
                        else
                        {
                            Debug.LogError($"[Enemy] Skill Not Found:{select[1]}");
                            return;
                        }
                        break;
                    case ActionBase.Action_Type.Escape:
                        selectData.Action = enemyManager.ActionEscape;
                        selectData.Target = CurrentEnemy.Num;
                        break;
                }
                selectData.Action.Chara = CurrentEnemy;     // ToDo: たぶんこれだめ、敵キャラのポインタが変わるので
                BattleSystem.Instance.SelectDatas.Add(selectData);
            }
        }

        private ActionSkill SerachActionSkill(string _skillName)
        {
            EnemyManager enemyManager = BattleSystem.Instance.EnemyManager;
            foreach(ActionSkill skill in enemyManager.ActionSkills)
            {
                if(skill.name == _skillName)
                {
                    return skill;
                }
            }
            return null;
        }
    }
}