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
        public enum Action_Target
        {
            None,
            Actor,
            Enemy_Solo,
            Enemy_All,
            Enemy_Random,
        }

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

        [SerializeField] protected Action_Type actionType = Action_Type.None;
        public Action_Type ActionType { get { return actionType; } }

        [SerializeField] protected Action_Target actionTarget = Action_Target.None;
        public Action_Target ActionTarget { get { return actionTarget; } }

        [SerializeField, NamedArray(typeof(Status))]
        protected Correction[] corrections = new Correction[(int)Status.NUM];     // 各ステータスの補正データ
        
        public CharacterBase Executor;        // 行動主のキャラデータ
        public List<CharacterBase> Targets = null;

        // エグゾースト使用したか
        protected bool usedExhaust = false;
        public bool UsedExhaust { get { return usedExhaust; } set { usedExhaust = value; } }
        
        /// <summary>
        /// 行動順を決める値を還す
        /// </summary>
        /// <returns>算出されたAgiの値</returns>
        public int GetActionOrderRate()
        {
            float result = Mathf.Clamp((Executor.GetStatus(Status.AGI) + corrections[(int)Status.AGI].Value) * corrections[(int)Status.AGI].Rate, 0, 100);
            return (int)result;
        }

        public virtual async UniTask Action(CharacterBase _executor, List<CharacterBase> _target)
        {
            Targets = _target;
        }

        /// <summary>
        /// 行動キャンセル
        /// </summary>
        public virtual void Cancel()
        {

        }

        public void Clone(ActionBase _actionBase)
        {
            name = _actionBase.name;
            actionType = _actionBase.actionType;
            actionTarget = _actionBase.actionTarget;
            corrections = _actionBase.corrections;
        }
    }
}