using UnityEngine;
using System.Collections;
using Star.Character;
using Star.Common.UI;
using Cysharp.Threading.Tasks;
using Star.Effect;
using UnityEngine.UI;
using DG.Tweening;

namespace Star.Battle.UI
{
    public class EnemyCell : MonoBehaviour
    {
        public int index = int.MinValue;
        Enemy enemy = null;
        [SerializeField] Image image;
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] CommonButton enemyButton = null;       // 敵キャラ本体の画像付き選択
        [SerializeField] GageBar hpBar;
        public GageBar HPBar { get { return hpBar; } }
        [SerializeField] EffectController effectController;
        public EffectController EffectController { get { return effectController; } }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="_enemy"></param>
        /// <param name="_index"></param>
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
        /// 選択時の動作
        /// </summary>
        private void IsSelect()
        {
            switch(BattleSystem.Instance.CurrentSelectData.Action.ActionTarget)
            {
                case ActionBase.Action_Target.Enemy_Solo:
                    {
                        BattleSystem.Instance.TargetsSelected(enemy);
                        BattleSystem.Instance.SystemMsg = $"{enemy.GetName()}を選択中";
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 体力ゲージの更新
        /// </summary>
        /// <returns></returns>
        public async UniTask UpdateHPGage()
        {
            await hpBar.UpdateGage((float)enemy.GetCurrentStatus(Status.HP) / enemy.GetStatus(Status.HP));
        }

        /// <summary>
        /// エフェクトの再生
        /// </summary>
        /// <returns></returns>
        public async UniTask PlayEffect()
        {
            effectController.Play();
            await effectController.EndDelay();
        }

        /// <summary>
        /// エフェクトアニメーションの設定
        /// </summary>
        /// <param name="_animName"></param>
        public void SetAnim(string _animName)
        {
            SpriteEffectManager.Instance.SetEffect(_animName, effectController);
        }

        public async UniTask OnDelete()
        {
            // Todo: 消滅アニメーション流す等
            canvasGroup.DOFade(0, 0.5f);      // 表示を消す
        }
    }
}