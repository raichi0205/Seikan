using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Star.Common.UI;

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
        [SerializeField] EnemyUIController enemyUIController;
        [SerializeField] BattleFooter footer;
        public BattleFooter Footer { get { return footer; } }

        [SerializeField] CommonButton enemySelectEnter;

        public GameObject ShakeArea;

        public void Initialize()
        {
            actionSelectWindow.Initialize();
            footer.Initialize();

            enemyUIController.SetActiveButton(false);
            enemySelectEnter.onClick.AddListener(() =>
            {
                enemyUIController.SetActiveButton(false);
                enemySelectEnter.gameObject.SetActive(false);
                BattleSystem.Instance.EnemySelector.EnterSelectIndex();
            });
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
            // 攻撃対象の敵キャラの選択UIを有効に
            enemyUIController.SetActiveButton(true);
            enemySelectEnter.gameObject.SetActive(true);
        }

        public void UnActiveTargetEnemySelect()
        {
            // 攻撃対象の敵キャラの選択UIを有効に
            enemyUIController.SetActiveButton(false);
            enemySelectEnter.gameObject.SetActive(false);
        }
    }
}