using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Star.Battle;
using Star.Editor;

namespace Star.Character
{
    public enum Status
    {
        HP,
        MP,
        ATK,
        DEF,
        AGI,
        LUK,
        NUM
    }

    public class CharacterData : ScriptableObject
    {
        [NamedArray(typeof(Status))] public int[] status = new int[(int)Character.Status.NUM];          // ステータス値
        [SerializeField] string charaName = string.Empty;
        public string CharaName { get { return charaName; } }
    }
}