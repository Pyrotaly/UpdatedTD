using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerSO : ScriptableObject
    {
        public TowerInfoStruct TowerInfo;
    }

    [System.Serializable]
    public struct TowerInfoStruct
    {
        [Header("Base Information")]
        public string TowerName;
        public int ItemID;

        [Header("Combat Information")]
        public int Health;
        public int Damage;
        public float ProjectileSpeed;
        public float AttackRange;
        public float AttackCooldown;
        public GameObject TEMPProjectile;
        public string targetTag;
    }
}
