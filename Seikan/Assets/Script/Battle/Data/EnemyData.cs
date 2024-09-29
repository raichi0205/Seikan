using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Star.Character
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Battle/Character/EnemyData", order = 0)]
    public class EnemyData : CharacterData
    {
        [SerializeField] private string enemyName = string.Empty;
        public string EnemyName { get { return enemyName; } }
        [SerializeField] private string actionPatternScript = string.Empty;
        public string ActionPatternScript { get { return actionPatternScript; } }
    }
}