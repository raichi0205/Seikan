using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Star.Character
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Battle/Character/EnemyData", order = 0)]
    public class EnemyData : CharacterData
    {
        [SerializeField] private string enemyName = string.Empty;
    }
}