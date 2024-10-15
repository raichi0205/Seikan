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

        [SerializeField] private List<Enemy> enemies = new List<Enemy>();
        public List<Enemy> Enemies { get { return enemies; } }

        [SerializeField] ActionAttack actionAttack;
        public ActionAttack ActionAttack { get { return actionAttack; } }
        [SerializeField] ActionGuard actionGuard;
        public ActionGuard ActionGuard { get { return actionGuard; } }
        [SerializeField] ActionEscape actionEscape;
        public ActionEscape ActionEscape { get { return actionEscape; } }
        [SerializeField] List<ActionSkill> actionSkills;
        public List<ActionSkill> ActionSkills { get { return actionSkills; } }

        public void Initialize()
        {
            // ToDo: 敵キャラデータの呼び出しを行う

            int num = 0;
            foreach(EnemyData enemyData in enemyDatas)
            {
                Enemy newEnemy = new Enemy();
                newEnemy.Initialize(enemyData, num);
                enemies.Add(newEnemy);
                num++;
            }

            enemyUIController.Initialize(enemies);
        }

        public Transform GetEnemyTransform(int _num)
        {
            return enemyUIController.GetEnemyTransform(_num);
        }

        public async UniTask EnemyActionThinking()
        {
            foreach(Enemy enemy in enemies)
            {
                await enemy.ActionThinking();
            }
        }

        public async UniTask UpdateEnemyHPGage(int _num)
        {
            await enemyUIController.GetEnemyCell(_num).UpdateGage();
        }
    }
}