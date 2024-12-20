using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Star.Battle.UI
{
    public class SkillUIController : MonoBehaviour
    {
        [SerializeField] SkillCell originalSkillCell;
        [SerializeField] ScrollRect skillList;
        [SerializeField] Transform content;
        public void Initialize(List<ActionSkill> _actionSkills)
        {
            _actionSkills.Sort((a, b) => a.SortPriority - b.SortPriority);
            foreach (ActionSkill skill in _actionSkills)
            {
                SkillCell newSkillCell = Instantiate(originalSkillCell);
                newSkillCell.Initialize(skill);
                newSkillCell.transform.SetParent(content, false);
            }
        }

        public void ActiveSelectWindow(bool _isActive)
        {
            skillList.gameObject.SetActive(_isActive);
        }

    }
}