using UnityEngine;
using System.Collections;
using Star.Common.UI;

namespace Star.Old.Battle.UI
{
    public class ActionSelectCellBase : MonoBehaviour
    {
        [SerializeField] protected ActionBase action;
        [SerializeField] protected CommonButton button;

        public virtual void Initialize()
        {
            button.onClick.AddListener(() => { Select(); });
        }

        public virtual void Select()
        {
            // 選択内容を記録
            action.Chara = BattleSystem.Instance.Actor;
            BattleSystem.Instance.CurrentSelectData.Action = action;
            BattleSystem.Instance.CurrentSelectData.Target = action.DefaultTargetNum;       // デフォのターゲットを指定する
            ActionSelector.Instance.Selected();
        }
    }
}