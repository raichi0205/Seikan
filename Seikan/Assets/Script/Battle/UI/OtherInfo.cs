using UnityEngine;
using System.Collections;
using TMPro;

namespace Star.Battle.UI
{
    public class OtherInfo : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI turnNum;

        /// <summary>
        /// ターン数表記の更新
        /// </summary>
        /// <param name="_turn"></param>
        public void UpdateTurn(int _turn)
        {
            turnNum.text = _turn.ToString();
        }
    }
}