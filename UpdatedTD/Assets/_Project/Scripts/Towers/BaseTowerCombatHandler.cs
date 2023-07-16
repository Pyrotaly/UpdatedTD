using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerCombatHandler : MonoBehaviour, IDamageable
    {
        protected List<GameObject> targetList = new List<GameObject>();
        private GameObject towerRadius;

        protected int hitPoints;

        private Dictionary<Stat, dynamic> localStatsDictionary;

        protected float projectileSpeed;
        protected float attackCooldown;
        protected GameObject TEMPProjectile;

        //For bullet spawning
        protected int damage;
        protected string targetTag;

        protected float nextAttackTime = 0f;

        //Test function
        public void SetUpLocalDictionary(BaseTowerSO test)
        {
            localStatsDictionary = new Dictionary<Stat, dynamic>(test.StatsDictionary); //Copy dictionary as a new object, not reference
        }

        //TODO : Remove this maybe?
        public void SetUpTowerAttackParameters(TowerInfoStruct towerStruct, GameObject towerRadiusReference)
        {
            hitPoints = towerStruct.HitPoints;
            damage = towerStruct.Damage;
            projectileSpeed = towerStruct.ProjectileSpeed;
            attackCooldown = towerStruct.AttackCooldown;
            TEMPProjectile = towerStruct.TEMPProjectile;
            targetTag = towerStruct.targetTag;
            TEMPProjectile.GetComponent<Projectile>().SetUp(damage, targetTag);
            towerRadius = towerRadiusReference;

            towerRadius.GetComponent<TowerRadiusTargetList>().ListUpdated += OnListUpdated;
        }

        //This function called from skill upgrades system
        //TODO : Ask about what is params
        //TODO : When adding save system, plan to call AlterStats but must be d
        public void AlterStats(params KeyValuePair<Stat, dynamic>[] pair)
        {
            foreach (KeyValuePair<Stat, dynamic> kvp in pair)
            {
                if (localStatsDictionary.ContainsKey(kvp.Key))
                {
                    localStatsDictionary[kvp.Key] = kvp.Value;

                    Debug.Log("Second: " + kvp.Value);
                }
            }
        }

        private void OnListUpdated(List<GameObject> updatedList) { targetList = updatedList; }

        private void OnDestroy()
        {
            towerRadius.GetComponent<TowerRadiusTargetList>().ListUpdated -= OnListUpdated;
        }

        public abstract void Attack();

        public void AlterCurrentHitPoints(int hitPointAlterAmount)
        {
            //TODO : Die function
            hitPoints += hitPointAlterAmount;

            if (hitPoints <= 0) { Debug.Log("Die"); }
        }
    }
}
