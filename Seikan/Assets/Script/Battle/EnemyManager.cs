using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Star.Character;
using Star.Battle.UI;
using Cysharp.Threading.Tasks;

namespace Star.Battle
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private List<EnemyData> enemyDatas = new List<EnemyData>();
        public List<EnemyData> EnemyDatas { get { return enemyDatas; } }

        [SerializeField] EnemyUIController enemyUIController;

        private List<Enemy> enemies = new List<Enemy>();
        public List<Enemy> Enemies { get { return enemies; } }

        public void Initialize()
        {
            // ToDo: 敵キャラデータの呼び出しを行う

            foreach(EnemyData enemyData in enemyDatas)
            {
                Enemy newEnemy = new Enemy();
                newEnemy.Initialize(enemyData);
                enemies.Add(newEnemy);
            }

            enemyUIController.Initialize(enemyDatas);
        }

        public async UniTask EnemyActionThinking()
        {
            foreach(Enemy enemy in enemies)
            {
                await enemy.ActionThinking();
            }
        }
    }
}