using UnityEngine;
using System.Collections;
using Cysharp.Threading.Tasks;
using Star.Battle;

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

        public void Initialize(ActorData _actorData)
        {
            selectCountMax = _actorData.SelectCountMax;
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
    }
}