using UnityEngine;
using System.Collections.Generic;
using Star.Common;
using Star.Battle;
using System;

namespace Star.Character {
    public class EnemyLuaBridge : Singleton<EnemyLuaBridge>
    {
        Enemy enemy = null;
        public Enemy Enemy { get { return enemy; } set { enemy = value; } }

        /// <summary>
        /// 敵の行動選択
        /// 敵の行動選択Luaスクリプトから呼び出す
        /// </summary>
        /// <param name="_select">選択した行動</param>
        public void SelectAction(string _select)
        {
            if(enemy == null)
            {
                Debug.LogError($"[Enemy]行動する敵が設定されていません");
                return;
            }

            Debug.Log($"[Enemy][Select]{enemy.Num}:{_select}");
            
            ActionBase.Action_Type action_Type;

            string[] select = _select.Split('/');       // 選択内容/スキル名/対象選択

            SelectData selectData = new SelectData();
            selectData.Executor = enemy;
            if (Enum.TryParse(select[0], out action_Type))
            {
                switch (action_Type)
                {
                    case ActionBase.Action_Type.Attack:
                        ActionAttack actionAttack = new ActionAttack();
                        actionAttack.Clone(EnemyManager.Instance.ActionAttack);
                        selectData.Action = actionAttack;
                        selectData.Targets.Add(BattleSystem.Instance.Actor);    // 主人公への行動
                        break;
                    case ActionBase.Action_Type.Guard:
                        ActionGuard actionGuard = new ActionGuard();
                        actionGuard.Clone(EnemyManager.Instance.ActionGuard);
                        selectData.Action = actionGuard;
                        selectData.Targets.Add(enemy);          // 自分への行動
                        break;
                    case ActionBase.Action_Type.Skill:
                        ActionSkill skill = new ActionSkill();
                        skill.Clone(SerachActionSkill(select[1]));
                        if(skill != null)
                        {
                            selectData.Action = skill;
                            int selectTarget = -1;
                            if(select.Length >= 3)
                            {
                                if (!(int.TryParse(select[2], out selectTarget)))
                                {
                                    selectTarget = 0;
                                }
                            }
                            selectData.Targets = SelectTarget(skill, selectTarget);
                        }
                        else
                        {
                            Debug.LogError($"[Enemy] Skill Not Found:{select[1]}");
                            return;
                        }
                        break;
                    case ActionBase.Action_Type.Escape:
                        ActionEscape actionEscape = new ActionEscape();
                        actionEscape.Clone(EnemyManager.Instance.ActionEscape);
                        selectData.Action = actionEscape;
                        selectData.Targets.Add(enemy);          // 自分への行動
                        break;
                }
                selectData.Action.Executor = enemy;
                BattleSystem.Instance.ActionScheduler.SelectDatas.Add(selectData);
            }
        }

        private List<CharacterBase> SelectTarget(ActionBase _action, int _target = 0)
        {
            List<CharacterBase> result = new List<CharacterBase>();
            switch (_action.ActionTarget)
            {
                case ActionBase.Action_Target.Actor:
                    result.Add(BattleSystem.Instance.Actor);
                    break;
                case ActionBase.Action_Target.Enemy_Solo:
                    if (EnemyManager.Instance.FieldEnemies.Count - 1 < _target)
                    {
                        result.Add(EnemyManager.Instance.FieldEnemies[_target]);
                    }
                    result.Add(EnemyManager.Instance.FieldEnemies[0]);
                    break;
                case ActionBase.Action_Target.Enemy_All:
                    result.AddRange(EnemyManager.Instance.FieldEnemies);
                    break;
                case ActionBase.Action_Target.Enemy_Random:
                    result.Add(EnemyManager.Instance.FieldEnemies[UnityEngine.Random.Range(0,EnemyManager.Instance.FieldEnemies.Count - 1)]);
                    break;
            }
            return result;
        }

        private ActionSkill SerachActionSkill(string _skillName)
        {
            foreach(ActionSkill skill in EnemyManager.Instance.ActionSkills)
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