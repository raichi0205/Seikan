using UnityEngine;
using System.Collections;
using Star.Common.UI;
using UnityEngine.UI;

namespace Star.Battle.UI
{
    public class ActionSelectWindow : MonoBehaviour
    {
        [SerializeField] CommonButton skillButton;
        [SerializeField] ScrollRect skillList;

        public void Initialize()
        {
            skillButton.onClick.AddListener(OpenSkillList);
        }

        public void OpenSkillList()
        {
            skillList.gameObject.SetActive(true);
        }
    }
}