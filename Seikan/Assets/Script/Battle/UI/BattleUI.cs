using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Star.Battle
{
    /// <summary>
    /// 戦闘画面のUI制御
    /// </summary>
    public class BattleUI : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI systemMsgUi;
        public TextMeshProUGUI SystemMsgUi { get { return systemMsgUi; } }

    }
}