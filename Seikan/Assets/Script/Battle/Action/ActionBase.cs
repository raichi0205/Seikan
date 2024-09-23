using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Star.Character;

namespace Star.Battle
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "ActionData", menuName = "Battle/Action/ActionData", order = 0)]
    public class ActionBase : ScriptableObject
    {
        /// <summary>
        /// 補正パラメータ
        /// </summary>
        [System.Serializable]
        public class Correction
        {
            public int Value = 0;           // 加減値
            public float Rate = 0;          // 補正倍率
        }

        [SerializeField] Correction[] corrections = new Correction[(int)Status.NUM];     // 各ステータスの補正データ
        public CharacterData CharaData;        // 行動主のキャラデータ

        /// <summary>
        /// 行動順を決める値を還す
        /// </summary>
        /// <returns>算出されたAgiの値</returns>
        public int GetActionOrderRate()
        {
            float result = (CharaData.GetStatus(Status.AGI) + corrections[(int)Status.AGI].Value) * corrections[(int)Status.AGI].Rate;
            result *= 100;
            return (int)result;
        }
    }
}