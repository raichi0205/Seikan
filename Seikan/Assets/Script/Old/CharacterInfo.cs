using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Star.Old.Battle;
using Star.Old.Character;
using Star.Battle.UI;

namespace Star.Old.Battle.UI
{
    public class CharacterInfo : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI charaName;
        public TextMeshProUGUI CharaName { get { return charaName; } }
        [SerializeField] GageBar hpBar;
        public GageBar HPBar { get { return hpBar; } }
        [SerializeField] GageBar spBar;
        public GageBar SPBar { get { return spBar; } }

        public void Initialize()
        {
            Actor actor = BattleSystem.Instance.Actor;
            hpBar.UpdateValueText(actor.GetCurrentStatus(Status.HP), actor.GetStatus(Status.HP));
            spBar.UpdateValueText(actor.GetCurrentStatus(Status.SP), actor.GetStatus(Status.SP));
        }
    }
}