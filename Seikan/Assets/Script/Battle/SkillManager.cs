using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Battle.UI;

namespace Star.Battle
{
    public class SkillManager : MonoBehaviour
    {
        [SerializeField] List<ActionSkill> actionSkills;
        [SerializeField] SkillUIController skillUIController;
        public void Initialize()
        {
            skillUIController.Initialize(actionSkills);
        }
    }
}