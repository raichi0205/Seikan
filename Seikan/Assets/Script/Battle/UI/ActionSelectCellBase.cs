using UnityEngine;
using System.Collections;
using Star.Battle;
using Star.Character;
using Star.Common.UI;

namespace Star.Battle.UI
{
    public class ActionSelectCellBase : MonoBehaviour
    {
        [SerializeField] ActionBase action;
        [SerializeField] CommonButton button;

        public virtual void Initialize()
        {
            button.onClick.AddListener(() => { Select(); });
        }

        public virtual void Select()
        {
            ActionSelector.Instance.Selected();
        }
    }
}