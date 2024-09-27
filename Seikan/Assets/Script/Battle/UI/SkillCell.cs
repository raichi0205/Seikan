using UnityEngine;
using System.Collections;
using TMPro;

namespace Star.Battle.UI
{
    public class SkillCell : ActionSelectCellBase
    {
        [SerializeField] TextMeshProUGUI skillName;
        public void Initialize(ActionSkill _skill)
        {
            action = _skill;
            skillName.name = _skill.SkillName;
            base.Initialize();
        }
    }
}