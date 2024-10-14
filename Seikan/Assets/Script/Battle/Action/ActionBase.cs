using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Star.Character;
using Cysharp.Threading.Tasks;
using Star.Editor;

namespace Star.Battle
{
    [CreateAssetMenu(fileName = "ActionData", menuName = "Battle/Action/ActionData", order = 0)]
    public class ActionBase : ScriptableObject
    {
        public enum Action_Type
        {
            None,
            Attack,
            Guard,
            Skill,
            Exhaust,
            Escape,
        }

        /// <summary>
        /// 補正パラメータ
        /// </summary>
        [System.Serializable]
        public class Correction
        {
            public int Value = 0;           // 加減値
            public float Rate = 1;          // 補正倍率
        }

        public int DefaultTargetNum = int.MinValue;
        [SerializeField] protected Action_Type actionType = Action_Type.None;
        public Action_Type ActionType { get { return actionType; } }

        [SerializeField, NamedArray(typeof(Status))]
        protected Correction[] corrections = new Correction[(int)Status.NUM];     // 各ステータスの補正データ
        
        public CharacterBase Chara;        // 行動主のキャラデータ
        protected CharacterBase target = null;

        /// <summary>
        /// 行動順を決める値を還す
        /// </summary>
        /// <returns>算出されたAgiの値</returns>
        public int GetActionOrderRate()
        {
            float result = (Chara.GetStatus(Status.AGI) + corrections[(int)Status.AGI].Value) * corrections[(int)Status.AGI].Rate;
            result *= 100;
            return (int)result;
        }

        public virtual async UniTask Action(CharacterBase _executor, CharacterBase _target)
        {
            target = _target;
        }

        public virtual void ActionToEnemy(List<Enemy> _targets)
        {

        }
    }
}