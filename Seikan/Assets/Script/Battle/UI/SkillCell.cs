using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Star.Battle;

namespace Star.Battle.UI
{
    public class SkillCell : ActionSelectCell
    {
        [SerializeField] TextMeshProUGUI skillName;
        [SerializeField] TextMeshProUGUI skillCost;
        [SerializeField] Image exhaustImage;
        public void Initialize(ActionSkill _skill)
        {
            action = _skill;
            skillName.text = _skill.SkillName;                          // スキル名
            var sp = _skill.GetCorrection(Character.Status.SP);
            skillCost.text = sp.Value.ToString();                       // 消費コスト
            exhaustImage.gameObject.SetActive(_skill.UseExhaust);       // エグゾーストを必要とするスキル

            button.onClick.AddListener(() => 
            {
                ActionSkill actionSkill = new ActionSkill();
                actionSkill.Clone(_skill);
                BattleSystem.Instance.CurrentSelectData.Action = actionSkill; 
                BattleSystem.Instance.SkillSelected(actionSkill);
            });
        }
    }
}