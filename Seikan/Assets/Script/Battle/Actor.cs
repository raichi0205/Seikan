using UnityEngine;
using System.Collections;

namespace Star.Character
{
    [System.Serializable]
    public class Actor : CharacterBase
    {
        private int selectCountMax = 3;         // 一ターンで行動できる回数
        public int SelectCounter = 0;           // 一ターンで行動選択した回数

        /// <summary>
        /// 残り選択可能回数の取得
        /// </summary>
        /// <returns>残り選択可能回数</returns>
        public int GetSelectCount()
        {
            return selectCountMax - SelectCounter;
        }
    }
}