using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Star.Character;

namespace Star.Battle.UI
{
    public class CharacterInfo : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI charaName;
        public TextMeshProUGUI CharaName { get { return charaName; } }
        [SerializeField] GageBar hpBar;
        public GageBar HPBar { get { return hpBar; } }
        [SerializeField] GageBar spBar;
        public GageBar SPBar { get { return spBar; } }
        [SerializeField] Image exhaustActiveImage;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            Actor actor = BattleSystem.Instance.Actor;
            charaName.text = actor.GetName();
            hpBar.UpdateValueText(actor.GetCurrentStatus(Status.HP), actor.GetStatus(Status.HP));
            spBar.UpdateValueText(actor.GetCurrentStatus(Status.SP), actor.GetStatus(Status.SP));
        }

        /// <summary>
        /// エグゾーストの使用可否の表示
        /// </summary>
        public void UpdateExhaustActive()
        {
            if(BattleSystem.Instance.Actor.CurrentExhaust >= 100)
            {
                exhaustActiveImage.gameObject.SetActive(true);
            }
            else
            {
                exhaustActiveImage.gameObject.SetActive(false);
            }
        }
    }
}