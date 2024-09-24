using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Character;
using Star.Battle.UI;

namespace Star.Battle
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<EnemyData> enemies = new List<EnemyData>();
        public List<EnemyData> Enemies { get { return enemies; } }

        [SerializeField] EnemyUIController enemyUIController;

        public void Initialize()
        {
            // ToDo: 敵キャラデータの呼び出しを行う
            enemyUIController.Initialize(enemies);
        }
    }
}