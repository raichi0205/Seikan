using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Battle;
using Star.Character;

namespace Star.Battle.UI
{
    public class EnemyUIController : MonoBehaviour
    {
        [SerializeField] EnemyCell originEnemyCell;
        private List<EnemyCell> enemyCells = new List<EnemyCell>();

        public void Initialize(List<EnemyData> _enemies)
        {
            foreach(EnemyData enemy in _enemies)
            {
                EnemyCell newCell = Instantiate(originEnemyCell);
                newCell.Initialize(enemy, enemyCells.Count);
                newCell.transform.SetParent(transform);
                enemyCells.Add(newCell);
            }
        }
    }
}