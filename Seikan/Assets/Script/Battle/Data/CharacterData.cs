using System.Collections.Generic;
using UnityEngine;
using Star.Editor;

namespace Star.Character
{
    public enum Status
    {
        HP,
        SP,
        ATK,
        DEF,
        AGI,
        LUK,
        NUM
    }

    public class CharacterData : ScriptableObject
    {
        [NamedArray(typeof(Status))] public int[] status = new int[(int)Character.Status.NUM];          // ステータス値
        [SerializeField] protected string charaName = string.Empty;
        public string CharaName { get { return charaName; } }
    }
}