using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Character;
using Star.Battle.UI;

namespace Star.Battle
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<EnemyData> enemyDatas = new List<EnemyData>();
        public List<EnemyData> EnemyDatas { get { return enemyDatas; } }

        [SerializeField] EnemyUIController enemyUIController;

        private List<CharacterBase> enemies = new List<CharacterBase>();
        public List<CharacterBase> Enemies { get { return enemies; } }

        public void Initialize()
        {
            // ToDo: 敵キャラデータの呼び出しを行う

            foreach(EnemyData enemyData in enemyDatas)
            {
                CharacterBase newEnemy = new CharacterBase();
                newEnemy.Initialize(enemyData);
                enemies.Add(newEnemy);
            }

            enemyUIController.Initialize(enemyDatas);
        }
    }
}