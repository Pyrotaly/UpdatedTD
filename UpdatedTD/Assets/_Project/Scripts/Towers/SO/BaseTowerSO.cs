using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerSO : ScriptableObject
    {
        public TowerInfoStruct TowerInfo;

        public Dictionary<Stat, dynamic> StatsDictionary = new Dictionary<Stat, dynamic>();

        private void OnEnable()
        {
            StatsDictionary.Add(Stat.MaxHitpoints, TowerInfo.HitPoints);
            StatsDictionary.Add(Stat.Damage, TowerInfo.Damage);
            StatsDictionary.Add(Stat.ProjectileSpeed, TowerInfo.ProjectileSpeed);
            StatsDictionary.Add(Stat.AttackRange, TowerInfo.AttackRange);
            StatsDictionary.Add(Stat.AttackCooldown, TowerInfo.AttackCooldown);
            StatsDictionary.Add(Stat.Projectile, TowerInfo.TEMPProjectile);
            StatsDictionary.Add(Stat.TargetTag, TowerInfo.targetTag);
            StatsDictionary.Add(Stat.TargetLayer, TowerInfo.targetLayer);
            //DebugStatsDictionary();
        }

        private void DebugStatsDictionary()
        {
            foreach (KeyValuePair<Stat, dynamic> statEntry in StatsDictionary)
            {
                string statName = statEntry.Key.ToString();
                dynamic statValue = statEntry.Value;
                Debug.Log($"{statName}: {statValue}");
            }
        }
    }

    [System.Serializable]
    public struct TowerInfoStruct
    {
        [Header("Base Information")]
        public string TowerName;
        public int ItemID;

        [Header("Combat Information")]
        public int HitPoints;
        public int Damage;
        public float ProjectileSpeed;
        public float AttackRange;
        public float AttackCooldown;
        public GameObject TEMPProjectile;
        public string targetTag;
        public LayerMask targetLayer;
    }

    public enum Stat
    {
        MaxHitpoints,
        Damage,
        ProjectileSpeed,
        AttackRange,
        AttackCooldown,
        Projectile,
        TargetTag,   //TODO : Does target tag have to be on here or when i make projectiles more interesting, put tag there?
        TargetLayer
    }
}
