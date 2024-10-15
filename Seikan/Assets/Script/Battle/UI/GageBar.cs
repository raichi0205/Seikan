using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Star.Battle.UI
{
    public class GageBar : MonoBehaviour
    {
        [SerializeField] Image gageBarBack;
        [SerializeField] Image gageBar;
        [SerializeField] TextMeshProUGUI gageValue;

        public async UniTask UpdateGage(float _value, float _duration = 0.5f)
        {
            await gageBar.DOFillAmount(_value, _duration).AsyncWaitForCompletion();
        }

        public void UpdateValueText(int _currentValue, int _maxValue)
        {
            gageValue.text = $"{_currentValue}/{_maxValue}";
        }
    }
}