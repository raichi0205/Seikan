using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Star.Common;
using Cysharp.Threading.Tasks;
using Star.Core;
using Star.Character;
using Star.Battle.UI;
using Star.Effect;
using Star.Lua;
using Star.Sound;

namespace Star.Battle
{
    public class BattleSystem : SingletonMonoBehaviour<BattleSystem>
    {
        const int MaxTurn = 999;    // 最大ターン数
        [SerializeField] int currentTurn = 0;       // 現在のターン
        [SerializeField] int selectCount = 0;       // 行動選択の回数

        [SerializeField] BattleUIController battleUIController;     // 戦闘画面のUIコントローラ
        public BattleUIController BattleUIController { get { return battleUIController; } }

        // システムメッセージ
        string systemMsg = "";
        public string SystemMsg
        {
            get { return systemMsg; }
            set
            {
                if (battleUIController != null && battleUIController.SystemMsgUi != null)
                {
                    battleUIController.SystemMsgUi.text = systemMsg = value;
                }
            }
        }

        // 主人公データ
        [SerializeField] ActorData actorData;
        // 主人公の操作データ
        [SerializeField] Actor actor;
        public Actor Actor { get { return actor; } }

        [SerializeField] int refrainExhaust = 25;           // エグゾーストの回復量

        [SerializeField] private SelectData currentSelectData = null;
        public SelectData CurrentSelectData { get { return currentSelectData; } }
        bool isActionEnemy = true;

        [SerializeField] ActionScheduler actionScheduler = new ActionScheduler();
        public ActionScheduler ActionScheduler { get { return actionScheduler; } }

        /// <summary>
        /// 開始時処理
        /// </summary>
        private void Start()
        {
            Initialize();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private async void Initialize()
        {
            // todo: 別で呼ぶ
            await GameManager.Instance.Load();
            
            if (GameManager.Instance.ActorData == null)
            {
                // データがなければ指定初期データを使う
                actor.Initialize(actorData);
            }
            else
            {
                actor.Initialize(GameManager.Instance.ActorData);
            }

            await SoundManager.Instance.LoadAudios(SoundManager.MixerGroup.SE, "SE");
            await SpriteEffectManager.Instance.LoadEffectAssets();
            LuaSystem.Instance.StarLua("Battle/Main.lua");

            EnemyManager.Instance.Initialize();
            battleUIController.Initialize();

            TurnStart();
        }

        /// <summary>
        /// ターン開始
        /// </summary>
        private void TurnStart()
        {
            currentTurn++;      // ターンのカウント開始
            Debug.Log($"[BattleSystem] ターン開始:{currentTurn}");
            battleUIController.Footer.OtherInfo.UpdateTurn(currentTurn);

            if (currentTurn < MaxTurn)
            {
                // エグゾーストの回復
                actor.CurrentExhaust += refrainExhaust;
                BattleUIController.UpdateExhaustActive();

                // 行動選択
                ActionSelect();
            }
            else
            {
                // 最大ターンを超える場合敗北判定
                Defeat();
            }
        }

        /// <summary>
        /// 行動選択
        /// </summary>
        private void ActionSelect(bool _isActionEnemy = true)
        {
            Debug.Log($"[BattleSystem] 行動選択");

            SystemMsg = $"あと{selectCount}/{actor.SelectCountMax}";

            // 敵が行動する状態か
            isActionEnemy = _isActionEnemy;

            // アクション選択画面を出す
            battleUIController.OpenActionSelectWindow();

            SelectData selectData = new SelectData();
            currentSelectData = selectData;         
        }

        /// <summary>
        /// 行動選択後の処理
        /// </summary>
        public async void ActionSelected()
        {
            Debug.Log($"[BattleSystem] 行動選択完了");

            bool skipSelect = false;

            // 選択された行動に応じた画面を出す
            switch (currentSelectData.Action)
            {
                case ActionAttack attack:
                    battleUIController.ActiveTargetSelect();
                    battleUIController.CloseActionSelectWindow();
                    break;
                case ActionGuard guard:
                    battleUIController.CloseActionSelectWindow();
                    skipSelect = true;
                    break;
                case ActionSkill skill:
                    battleUIController.OpenSkillSelectWindow();
                    break;
                case ActionExhaust exhaust:
                    if (!actor.IsExhaust && actor.CurrentExhaust == 100)
                    {
                        await currentSelectData.Action.Action(actor, null);
                        selectCount--;
                        skipSelect = true;
                    }
                    else
                    {
                        Debug.Log($"[BattleSystem] Failed Exhaust");
                        return;
                    }
                    break;
                case ActionEscape escape:
                    // Todo: 逃走行動の処理を作る
                    SystemMsg = $"今は逃げられない";
                    battleUIController.CloseActionSelectWindow();
                    await UniTask.Delay(500);
                    battleUIController.OpenActionSelectWindow();
                    SystemMsg = $"あと{selectCount}/{actor.SelectCountMax}";
                    break;
            }

            // 選択データの作成
            currentSelectData.Executor = actor;            // 実行者の設定

            // 選択行動をしない
            if (skipSelect)
            {
                SelectApply();
            }
        }

        /// <summary>
        /// スキル選択
        /// </summary>
        public void SkillSelected(ActionSkill _skill)
        {
            Debug.Log($"[BattleSystem] スキル選択");
            // エグゾーストを使用するか
            if (_skill.UseExhaust)
            {
                // 使用する場合エグゾーストが有効になっていること
                if (!actor.IsExhaust)
                {
                    // 使用していない場合処理を抜ける
                    return;
                }
            }

            // SPが足りるか
            if(actor.GetCurrentStatus(Status.SP) - (actionScheduler.GetSelectTotalSP() + _skill.GetCorrection(Status.SP).Value) < 0)
            {
                // SPが足りない
                return;
            }

            battleUIController.CloseSkillSelectWindow();
            battleUIController.CloseActionSelectWindow();

            // Memo: 場合によっては目標選択を省く
            battleUIController.ActiveTargetSelect();
        }
        
        /// <summary>
        /// ターゲット選択
        /// </summary>
        /// <param name="_targets"></param>
        public void TargetsSelected(CharacterBase _target = null)
        {
            Debug.Log($"[BattleSystem] ターゲット選択");

            currentSelectData.Targets.Clear();

            if (_target != null)
            {
                CurrentSelectData.Targets.Add(_target);
            }
        }

        /// <summary>
        /// 選択内容確定
        /// </summary>
        public void SelectApply()
        {
            Debug.Log($"[BattleSystem] 選択完了");

            switch (currentSelectData.Action.ActionTarget)
            {
                case ActionBase.Action_Target.Actor:
                    CurrentSelectData.Targets.Add(Actor);
                    break;
                case ActionBase.Action_Target.Enemy_Solo:
                    break;
                case ActionBase.Action_Target.Enemy_All:
                case ActionBase.Action_Target.Enemy_Random:
                    foreach (Enemy enemy in EnemyManager.Instance.FieldEnemies)
                    {
                        CurrentSelectData.Targets.Add(enemy);
                    }
                    break;
            }

            // エグゾーストを消費する
            switch (currentSelectData.Action)
            {
                case ActionAttack attack:
                case ActionGuard guard:
                case ActionSkill skill:
                    if (actor.IsExhaust)
                    {
                        actor.IsExhaust = false;
                    }
                    break;
                case ActionExhaust exhaust:
                    break;
                case ActionEscape escape:
                    break;
            }

            actionScheduler.SelectDatas.Add(currentSelectData);
            currentSelectData.Action.Executor = currentSelectData.Executor;
            SelectEnd();
        }

        /// <summary>
        /// 行動のすべての選択を終えた時に呼び出す
        /// </summary>
        private void SelectEnd()
        {
            Debug.Log($"[BattleSystem] 行動選択終了");

            battleUIController.CloseActionSelectWindow();

            selectCount++;
            if (selectCount < actor.SelectCountMax)
            {
                // 次の行動選択に入る
                Debug.Log($"[BattleSystem] 次の選択に入る");

                ActionSelect(isActionEnemy);
            }
            else
            {
                // 選択回数をリセット
                selectCount = 0;

                // 敵が行動するか
                if (isActionEnemy)
                {
                    // 敵の行動判断へ
                    EnemyThinking();
                }
                else
                {
                    // 行動実行
                    ActionExecute();
                }
            }
        }

        /// <summary>
        /// 敵の行動判断
        /// </summary>
        private async void EnemyThinking()
        {
            Debug.Log($"[BattleSystem] 敵の行動判断");

            SystemMsg = "思考中...";

            await EnemyManager.Instance.EnemyActionThinking();
            ActionExecute();
        }

        /// <summary>
        /// 行動実行
        /// </summary>
        private async void ActionExecute()
        {
            Debug.Log($"[BattleSystem] 選択された行動の実行");

            await actionScheduler.Action();

            actionScheduler.SelectDatas.Clear();        // 行動情報をリセット

            StatusProcess();
        }

        /// <summary>
        /// 行動キャンセル
        /// </summary>
        public void ActionCancel()
        {
            Debug.Log($"[BattleSystem] 選択された行動のキャンセル");

            if (actionScheduler.SelectDatas[^1].Action.GetType() != typeof(ActionExhaust))
            {
                // 消費した選択回数をリセット
                Debug.Log($"[BattleSystem] 行動選択の回復");
                selectCount--;
            }

            actionScheduler.Cancel();

            ActionSelect(isActionEnemy);
        }

        /// <summary>
        /// 状態異常処理
        /// </summary>
        private async void StatusProcess()
        {
            Debug.Log($"[BattleSystem] 状態異常の発動");

            // 状態の発動

            // 終了判定
            EndJudge(true);
        }

        /// <summary>
        /// 終了判定
        /// </summary>
        /// <param name="isTurnEnd">ターン終了するか</param>
        public async UniTask<bool> EndJudge(bool isTurnEnd = false)
        {
            Debug.Log($"[BattleSystem] 終了判定");

            bool actorIsDeth = await actor.CheckHP();
            bool enemyIsDeth = await EnemyManager.Instance.CheckHP();

            if (isTurnEnd && !actorIsDeth && !enemyIsDeth)
            {
                TurnEnd();
            }
            else if (enemyIsDeth)
            {
                Winner();
                return false;
            }
            else if (actorIsDeth)
            {
                Defeat();
                return false;
            }
            return true;
        }

        /// <summary>
        /// ターン終了
        /// </summary>
        private void TurnEnd()
        {
            Debug.Log($"[BattleSystem] ターン終了");
            TurnStart();
        }

        /// <summary>
        /// 勝利処理
        /// </summary>
        private void Winner()
        {
            Debug.Log($"[BattleSystem] 勝利");
            battleUIController.OpenWinnerWindow();
        }

        /// <summary>
        /// 敗北処理
        /// </summary>
        private void Defeat()
        {
            Debug.Log($"[BattleSystem] 敗北");
            battleUIController.OpenDefeatWindow();
        }
    }
}