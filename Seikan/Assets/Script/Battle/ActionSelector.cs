using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Common;
using Star.Battle.UI;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    public class ActionSelector : SingletonMonoBehaviour<ActionSelector>
    {
        [SerializeField] List<ActionSelectCell> actionSelectCellBases;

        public void Initialize()
        {
            foreach(var cell in actionSelectCellBases)
            {
                cell.Initialize();
            }
        }
    }
}