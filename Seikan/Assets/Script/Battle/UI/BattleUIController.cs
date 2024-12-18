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

        [SerializeField] CommonButton selectApply;                  // 選択内容決定
        [SerializeField] CommonButton actionSelectCancelButton;     // 行動選択キャンセル
        [SerializeField] CommonButton targetSelectCancelButton;     // 目標選択キャンセル

        public GameObject ShakeArea;

        [SerializeField] EffectController allEffect;
        public EffectController AllEffect { get { return allEffect; } }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            footer.Initialize();
            allEffect.Initialize();

            ActionSelector.Instance.Initialize();
            enemyUIController.SetActiveButton(false);
            selectApply.onClick.AddListener(() =>
            {
                if (!(BattleSystem.Instance.CurrentSelectData.Action.ActionTarget == ActionBase.Action_Target.Enemy_Solo)
                || BattleSystem.Instance.CurrentSelectData.Targets.Count > 0)
                {
                    enemyUIController.SetActiveButton(false);
                    selectApply.gameObject.SetActive(false);
                    targetSelectCancelButton.gameObject.SetActive(false);
                    BattleSystem.Instance.SelectApply();
                }
            });

            actionSelectCancelButton.onClick.AddListener(BattleSystem.Instance.ActionCancel);
            targetSelectCancelButton.onClick.AddListener(CancelTargetSelect);
        }

        /// <summary>
        /// 行動選択画面を開く
        /// </summary>
        public void OpenActionSelectWindow()
        {
            actionSelectWindow.gameObject.SetActive(true);      // Todo: アニメーションするようにする
            
            // 既に行動を選択しているか
            if(BattleSystem.Instance.ActionScheduler.SelectDatas.Count > 0)
            {
                // 行動選択キャンセルボタンの表示
                actionSelectCancelButton.gameObject.SetActive(true);
            }
            else
            {
                // 行動選択キャンセルボタンの非表示
                actionSelectCancelButton.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 行動選択画面を閉じる
        /// </summary>
        public void CloseActionSelectWindow()
        {
            // ToDo: 閉じるアニメーション待ち
            actionSelectWindow.gameObject.SetActive(false);
            
            // 行動選択キャンセルボタンの非表示
            actionSelectCancelButton.gameObject.SetActive(false);

            // スキル選択画面の非表示
            CloseSkillSelectWindow();
        }

        /// <summary>
        /// スキル選択画面の表示
        /// </summary>
        public void OpenSkillSelectWindow()
        {
            SkillManager.Instance.SkillUIController.ActiveSelectWindow(true);
        }

        /// <summary>
        /// スキル選択画面の非表示
        /// </summary>
        public void CloseSkillSelectWindow()
        {
            SkillManager.Instance.SkillUIController.ActiveSelectWindow(false);
        }

        /// <summary>
        /// 目標選択を有効に
        /// </summary>
        public void ActiveTargetSelect()
        {
            // 攻撃対象の敵キャラの選択UIを有効に
            enemyUIController.SetActiveButton(true);
            selectApply.gameObject.SetActive(true);
            targetSelectCancelButton.gameObject.SetActive(true);
        }

        /// <summary>
        /// 目標選択を無効に
        /// </summary>
        public void UnActiveTargetSelect()
        {
            // 攻撃対象の敵キャラの選択UIを無効に
            enemyUIController.SetActiveButton(false);
            selectApply.gameObject.SetActive(false);
            targetSelectCancelButton.gameObject.SetActive(false);
        }

        /// <summary>
        /// 目標選択画面から戻る
        /// </summary>
        public void CancelTargetSelect()
        {
            BattleSystem.Instance.CurrentSelectData.Action = null;
            BattleSystem.Instance.CurrentSelectData.Executor = null;
            UnActiveTargetSelect();
            OpenActionSelectWindow();
        }
    }
}