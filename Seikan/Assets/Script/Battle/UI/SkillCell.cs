using UnityEngine;
using System.Collections;
using TMPro;
using Star.Battle;

namespace Star.Battle.UI
{
    public class SkillCell : ActionSelectCell
    {
        [SerializeField] TextMeshProUGUI skillName;
        public void Initialize(ActionSkill _skill)
        {
            action = _skill;
            skillName.name = _skill.SkillName;
            button.onClick.AddListener(BattleSystem.Instance.SkillSelected);
            button.onClick.AddListener(() => 
            {
                ActionSkill actionSkill = new ActionSkill();
                actionSkill.Clone(_skill);
                BattleSystem.Instance.CurrentSelectData.Action = actionSkill; 
            });
        }
    }
}