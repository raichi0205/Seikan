using UnityEngine;
using System.Collections.Generic;
using Star.Common.UI;
using Star.Battle;
using UnityEngine.UI;

namespace Star.Battle.UI
{
    public class StateInfoCell : MonoBehaviour
    {
        [SerializeField] CommonButton button;
        public CommonButton Button { get { return button; } }
        public StateBase State { get; set; }
        [SerializeField] Image icon;
        public Image Icon { get { return icon; } }
    }
}