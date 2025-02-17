using UnityEngine;
using System.Collections;
using Cysharp.Threading.Tasks;
using Star.Character;

namespace Star.Battle
{
    public class PoisonState : StateBase
    {
        PoisonData poisonData;
        public PoisonData PoisonData { get { return poisonData; } set { stateData = poisonData = value; } }

        /// <summary>
        /// 状態の実行
        /// </summary>
        /// <param name="_exeChara"></param>
        /// <returns></returns>
        public override async UniTask Execute(CharacterBase _exeChara)
        {
            int hp = _exeChara.GetStatus(Status.HP);            // 現在HP取得
            int subHp = (int)(hp * poisonData.DecreaseRate);    // 減少するHPの量を決める
            _exeChara.SubCurrentStatus(Status.HP, subHp);       // 減少処理
            await _exeChara.UpdateGage(Status.HP);
            base.Execute(_exeChara);
        }
    }
}