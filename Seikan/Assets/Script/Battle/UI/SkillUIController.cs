using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Star.Battle.UI
{
    public class SkillUIController : MonoBehaviour
    {
        [SerializeField] SkillCell originalSkillCell;
        [SerializeField] Transform content;
        public void Initialize(List<ActionSkill> _actionSkills)
        {
            foreach(ActionSkill skill in _actionSkills)
            {
                SkillCell newSkillCell = Instantiate(originalSkillCell);
                newSkillCell.Initialize(skill);
                newSkillCell.transform.SetParent(content, false);
            }
        }
    }
}