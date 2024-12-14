using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Star.Common.UI;
using Star.Effect;

namespace Star.Battle.UI
{
    /// <summary>
    /// 戦闘画面のUI制御
    /// </summary>
    public class BattleUIController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI systemMsgUi;
        public TextMeshProUGUI SystemMsgUi { get { return systemMsgUi; } }
        [SerializeField] GameObject actionSelectWindow;
        [SerializeField] EnemyUIController enemyUIController;
        [SerializeField] BattleFooter footer;
        public BattleFooter Footer { get { return footer; } }

        [SerializeField] CommonButton enemySelectEnter;

        public GameObject ShakeArea;

        [SerializeField] EffectController allEffect;
        public EffectController AllEffect { get { return allEffect; } }

        public void Initialize()
        {
            footer.Initialize();
            allEffect.Initialize();

            ActionSelector.Instance.Initialize();
            enemyUIController.SetActiveButton(false);
            enemySelectEnter.onClick.AddListener(() =>
            {
                if (!(BattleSystem.Instance.CurrentSelectData.Action.ActionTarget == ActionBase.Action_Target.Enemy_Solo)
                || BattleSystem.Instance.CurrentSelectData.Targets.Count > 0)
                {
                    enemyUIController.SetActiveButton(false);
                    enemySelectEnter.gameObject.SetActive(false);
                    BattleSystem.Instance.SelectApply();
                }
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
            CloseSkillSelectWindow();
        }

        public void OpenSkillSelectWindow()
        {
            SkillManager.Instance.SkillUIController.ActiveSelectWindow(true);
        }

        public void CloseSkillSelectWindow()
        {
            SkillManager.Instance.SkillUIController.ActiveSelectWindow(false);
        }

        public void ActiveTargetSelect()
        {
            // 攻撃対象の敵キャラの選択UIを有効に
            enemyUIController.SetActiveButton(true);
            enemySelectEnter.gameObject.SetActive(true);
        }

        public void UnActiveTargetSelect()
        {
            // 攻撃対象の敵キャラの選択UIを無効に
            enemyUIController.SetActiveButton(false);
            enemySelectEnter.gameObject.SetActive(false);
        }
    }
}