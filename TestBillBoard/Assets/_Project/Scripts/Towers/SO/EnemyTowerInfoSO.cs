using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [CreateAssetMenu(fileName = "New Tower", menuName = "Tower/New Enemy Tower")]
    public class EnemyTowerInfoSO : BaseTowerSO
    {
        [Header("Enemy Information")]
        public float moveSpeed;
        public int PlayerHealthDamage = 1;
        public int GoldOnDeath = 100;
    }
}
