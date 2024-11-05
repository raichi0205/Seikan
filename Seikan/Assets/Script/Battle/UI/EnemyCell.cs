using UnityEngine;
using System.Collections;
using Star.Character;
using Star.Common.UI;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;
using Star.Effect;

namespace Star.Battle.UI
{
    public class EnemyCell : MonoBehaviour
    {
        public int index = int.MinValue;
        Enemy enemy = null;
        [SerializeField] CommonButton enemyButton = null;       // 敵キャラ本体の画像付き選択
        [SerializeField] GageBar hpBar;
        public GageBar HPBar { get { return hpBar; } }
        [SerializeField] EffectController effectController;
        public EffectController EffectController { get { return effectController; } }

        public void Initialize(Enemy _enemy, int _index)
        {
            index = _index;
            enemy = _enemy;
            enemyButton.onClick.AddListener(IsSelect);
            _ = hpBar.UpdateGage((float)_enemy.GetCurrentStatus(Status.HP) / _enemy.GetStatus(Status.HP), 0);
            effectController.Initialize();
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

        public async UniTask UpdateHPGage()
        {
            await hpBar.UpdateGage((float)enemy.GetCurrentStatus(Status.HP) / enemy.GetStatus(Status.HP));
        }

        public async UniTask PlayEffect()
        {
            effectController.Play();
            await effectController.EndDelay();
        }

        public void SetAnim(string _animName)
        {
            SpriteEffectManager.Instance.SetEffect(_animName, effectController);
        }
    }
}