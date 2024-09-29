using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Star.Battle;

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
        public int[] status = new int[(int)Character.Status.NUM];          // ステータス地
    }
}