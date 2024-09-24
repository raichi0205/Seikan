using UnityEngine;
using System.Collections;
using Star.Character;
using Star.Common.UI;
using UnityEngine.Events;

namespace Star.Battle.UI
{
    public class EnemyCell : MonoBehaviour
    {
        public int index = int.MinValue;
        EnemyData enemyData = null;
        [SerializeField] CommonButton enemyButton = null;       // 敵キャラ本体の画像付き選択

        public void Initialize(EnemyData _enemyData, int _index)
        {
            index = _index;
            enemyData = _enemyData;
            enemyButton.onClick.AddListener(IsSelect);
        }

        /// <summary>
        /// ボタンの有効性
        /// </summary>
        public void SetActive(bool _isActive)
        {
            enemyButton.enabled = _isActive;
        }

        /// <summary>
        /// カーソルが合わさった時の処理
        /// </summary>
        private void OnCursor()
        {

        }

        private void IsSelect()
        {
            BattleSystem.Instance.EnemySelector.SetSelectIndex(index);
        }
    }
}