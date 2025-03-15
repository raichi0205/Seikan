using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using Star.Character;
using Star.Common.UI;

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

        [SerializeField] CommonButton infoMenuButton;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            Actor actor = BattleSystem.Instance.Actor;
            charaName.text = actor.GetName();
            hpBar.UpdateValueText(actor.GetCurrentStatus(Status.HP), actor.GetStatus(Status.HP));
            spBar.UpdateValueText(actor.GetCurrentStatus(Status.SP), actor.GetStatus(Status.SP));

            // 詳細情報を開くボタンの設定
            infoMenuButton.onClick.AddListener(async() => 
            {
                PlayerInfoPopup playerInfoPopup = (PlayerInfoPopup)await PopupManager.Instance.GetPopup("Popup/PlayerInfoPopup");
                List<StateBase> states = new List<StateBase>();
                states.AddRange(BattleSystem.Instance.Actor.States[StateDataBase.Timing.ActionAfter]);
                states.AddRange(BattleSystem.Instance.Actor.States[StateDataBase.Timing.TurnStart]);
                states.AddRange(BattleSystem.Instance.Actor.States[StateDataBase.Timing.TurnEnd]);
                playerInfoPopup.Initialize(states);
                await playerInfoPopup.Open();
            });
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