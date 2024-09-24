using UnityEngine;
using System.Collections;
using Star.Character;

namespace Star.Battle
{
    [System.Serializable]
    public class SelectData
    {
        [SerializeField] private ActionBase action;
        public ActionBase Action { get { return action; } set { action = value; } }
        [SerializeField] private int selectEnemy = int.MinValue;
        public int SelectEnemy { get { return selectEnemy; } set { selectEnemy = value; } }
    }
}