using UnityEngine;
using System.Collections;
using Star.Common.UI;

namespace Star.Battle.UI
{
    public class ActionSelectCell : MonoBehaviour
    {
        [SerializeField] protected ActionBase action;
        [SerializeField] protected CommonButton button;

        public void Initialize()
        {
            button.onClick.AddListener(() => 
            {
                switch (action)
                {
                    case ActionAttack attack:
                        ActionAttack actionAttack = new ActionAttack();
                        actionAttack.Clone((ActionAttack)action);
                        BattleSystem.Instance.CurrentSelectData.Action = actionAttack;
                        break;
                    case ActionGuard guard:
                        ActionGuard actionGuard = new ActionGuard();
                        actionGuard.Clone((ActionGuard)action);
                        BattleSystem.Instance.CurrentSelectData.Action = actionGuard;
                        break;
                    case ActionSkill skill:
                        ActionSkill actionSkill = new ActionSkill();
                        actionSkill.Clone((ActionSkill)action);
                        BattleSystem.Instance.CurrentSelectData.Action = actionSkill;
                        break;
                    case ActionExhaust exhaust:
                        ActionExhaust actionExhaust = new ActionExhaust();
                        actionExhaust.Clone((ActionExhaust)action);
                        BattleSystem.Instance.CurrentSelectData.Action = actionExhaust;
                        break;
                    case ActionEscape escape:
                        ActionEscape actionEscape = new ActionEscape();
                        actionEscape.Clone((ActionEscape)action);
                        BattleSystem.Instance.CurrentSelectData.Action = actionEscape;
                        break;
                    default:
                        Debug.LogError($"[Action][Select] 未定義のクラスが操作されました");
                        break;
                }
            });
            button.onClick.AddListener(BattleSystem.Instance.ActionSelected);
        }
    }
}