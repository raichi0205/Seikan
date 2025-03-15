using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Star.Battle;
using System;

namespace Star.Character
{
    [System.Serializable]
    public class Actor : CharacterBase
    {
        [SerializeField] private int selectCountMax = 1;         // 一ターンで行動できる回数
        public int SelectCountMax { get { return selectCountMax; } }

        [SerializeField] private int currentExhaust = 100;      // Exhaustの量
        public int CurrentExhaust 
        {
            get 
            { 
                return currentExhaust; 
            }
            set 
            {
                currentExhaust = value;
                if(currentExhaust > 100)
                {
                    currentExhaust = 100;
                }
                else if(currentExhaust < 0)
                {
                    currentExhaust = 0;
                }
            } 
        }
        public bool IsExhaust = false;          // Exhaustの使用状態

        [SerializeField] private List<ActionSkill> skills = new List<ActionSkill>();
        public List<ActionSkill> Skills { get { return skills; } }

        public UnityAction<StateBase> OnAddState;       // 状態が増えた時に実行する
        public UnityAction<StateBase> OnSubState;       // 状態が減った時に実行する

        public void Initialize(ActorData _actorData)
        {
            selectCountMax = _actorData.SelectCountMax;
            skills.AddRange(_actorData.DefaultSkills);
            skills.AddRange(_actorData.HoldSkills);
            base.Initialize(_actorData);
        }

        public override async UniTask<bool> CheckHP()
        {
            if (currentStatus[(int)Status.HP] <= 0)
            {
                // Todo: 延命スキルがあるかチェックする
                // 無ければ死亡判定
                BattleSystem.Instance.SystemMsg = "力尽きた";
                await UniTask.Delay(2500);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 状態を付与
        /// </summary>
        /// <param name="_stateName"></param>
        /// <returns></returns>
        public override async UniTask<StateBase> GrantState(string _stateName)
        {
            var state = await base.GrantState(_stateName);

            // ポップアップの更新が必要であれば行う
            OnAddState(state);
            return state;
        }

        /// <summary>
        /// ゲージ更新処理
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        public async override UniTask UpdateGage(Status _status = Status.HP)
        {
            switch (_status)
            {
                case Status.HP:
                    await BattleSystem.Instance.BattleUIController.Footer.CharacterInfo.HPBar.UpdateGage((float)currentStatus[(int)Status.HP] / GetStatus(Status.HP));
                    BattleSystem.Instance.BattleUIController.Footer.CharacterInfo.HPBar.UpdateValueText(currentStatus[(int)Status.HP], GetStatus(Status.HP));
                    break;
                case Status.SP:
                    await BattleSystem.Instance.BattleUIController.Footer.CharacterInfo.SPBar.UpdateGage((float)currentStatus[(int)Status.SP] / GetStatus(Status.SP));
                    BattleSystem.Instance.BattleUIController.Footer.CharacterInfo.SPBar.UpdateValueText(currentStatus[(int)Status.SP], GetStatus(Status.SP));
                    break;
            }
        }
    }
}