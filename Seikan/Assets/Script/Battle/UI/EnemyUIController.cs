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
        [Header("don't setting!!")]
        [SerializeField] private List<EnemyCell> enemyCells = new List<EnemyCell>();

        public void Initialize(List<Enemy> _enemies)
        {
            foreach(Enemy enemy in _enemies)
            {
                EnemyCell newCell = Instantiate(originEnemyCell);
                newCell.Initialize(enemy, enemyCells.Count);
                newCell.transform.SetParent(transform, false);
                enemyCells.Add(newCell);
            }
        }

        public EnemyCell GetEnemyCell(int _num)
        {
            if (_num < enemyCells.Count && _num >= 0)
            {
                return enemyCells[_num];
            }
            return null;
        }

        public Transform GetEnemyTransform(int _num)
        {
            if (_num < enemyCells.Count && _num >= 0)
            {
                return enemyCells[_num].transform;
            }
            return null;
        }

        public void SetActiveButton(bool _isActive)
        {
            foreach(EnemyCell cell in enemyCells)
            {
                cell.SetActive(_isActive);
            }
        }
    }
}