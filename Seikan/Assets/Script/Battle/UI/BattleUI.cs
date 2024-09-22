using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Star.Battle.UI
{
    /// <summary>
    /// 戦闘画面のUI制御
    /// </summary>
    public class BattleUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI systemMsgUi;
        public TextMeshProUGUI SystemMsgUi { get { return systemMsgUi; } }
        [SerializeField] ActionSelectWindow actionSelectWindow;

        public void Initialize()
        {
            actionSelectWindow.Initialize();
        }

        public void OpenActionSelectWindow()
        {
            actionSelectWindow.gameObject.SetActive(true);      // アニメーションするようにする
        }

        public void CloseActionSelectWindow()
        {
            // ToDo: 閉じるアニメーション待ち
            actionSelectWindow.gameObject.SetActive(false);
        }

        public void ActiveTargetEnemySelect()
        {
            // ToDo: 攻撃対象の敵キャラの選択UIを有効に
        }
    }
}