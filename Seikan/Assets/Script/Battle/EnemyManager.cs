using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Star.Common;
using Star.Battle.UI;
using Star.Character;

namespace Star.Battle
{
    public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
    {
        [SerializeField] private List<EnemyData> enemyDatas = new List<EnemyData>();
        //public List<EnemyData> EnemyDatas { get { return enemyDatas; } }

        [SerializeField] private List<Enemy> enemies = new List<Enemy>();
        public List<Enemy> Enemies { get { return enemies; } }

        [SerializeField] private List<Enemy> fieldEnemies;
        public List<Enemy> FieldEnemies { get { return fieldEnemies; } }

        [SerializeField] EnemyUIController enemyUIController;
        public EnemyUIController EnemyUIController { get { return enemyUIController; } }

        //------------------------------------------------------------------------
        // 敵の行動
        //------------------------------------------------------------------------
        [SerializeField] ActionAttack actionAttack;
        public ActionAttack ActionAttack { get { return actionAttack; } }
        [SerializeField] ActionGuard actionGuard;
        public ActionGuard ActionGuard { get { return actionGuard; } }
        [SerializeField] ActionEscape actionEscape;
        public ActionEscape ActionEscape { get { return actionEscape; } }
        [SerializeField] List<ActionSkill> actionSkills = new List<ActionSkill>();
        public List<ActionSkill> ActionSkills { get { return actionSkills; } }

        public void Initialize()
        {
            // ToDo: 敵キャラデータの呼び出しを行う

            int num = 0;
            foreach (EnemyData enemyData in enemyDatas)
            {
                Enemy newEnemy = new Enemy();
                newEnemy.Initialize(enemyData, num);
                enemies.Add(newEnemy);
                num++;
            }

            fieldEnemies = new List<Enemy>(enemies);            // 初期は出現する全部の敵を設定する
            enemyUIController.Initialize(enemies);
        }

        public Transform GetEnemyTransform(int _num)
        {
            return enemyUIController.GetEnemyTransform(_num);
        }

        public async UniTask EnemyActionThinking()
        {
            foreach (Enemy enemy in fieldEnemies)
            {
                await enemy.ActionThinking();
            }
        }

        public async UniTask PlayEffect(int _num, string _animName)
        {
            EnemyCell enemyCell = enemyUIController.GetEnemyCell(_num);
            enemyCell.SetAnim(_animName);
            await enemyCell.PlayEffect();
        }

        public async UniTask UpdateEnemyHPGage(int _num)
        {
            await enemyUIController.GetEnemyCell(_num).UpdateHPGage();
        }

        public async UniTask<bool> CheckHP()
        {
            List<Enemy> checkEnemy = new List<Enemy>(fieldEnemies);
            bool annihilation = true;          // 全滅フラグ
            foreach (Enemy enemy in checkEnemy)
            {
                if (enemy.currentStatus[(int)Status.HP] <= 0)
                {
                    await OnDeth(enemy.Num);
                    BattleSystem.Instance.SystemMsg = $"{enemy.GetName()}を倒した。";
                    await UniTask.Delay(500);
                    BattleSystem.Instance.SystemMsg = "";
                }
                else
                {
                    annihilation = false;       // 生存者がいるので全滅フラグ解除
                }
            }
            return annihilation;
        }

        public async UniTask OnDeth(int _num)
        {
            await enemyUIController.GetEnemyCell(_num).OnDelete();
            fieldEnemies.Remove(enemies[_num]);     // 特定の敵をフィールド上から削除
        }

        public void SetSkills(List<ActionSkill> _skills)
        {
            actionSkills = _skills;
        }
    }
}