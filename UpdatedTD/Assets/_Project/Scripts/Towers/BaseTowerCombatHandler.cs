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
        private bool isSetUp = false;

        protected virtual void Update()
        {
            //TODO idk if setup check does anything....
            if (!isSetUp) { return; }
            Attack();

            //TODO : Remove this testing
            KeyValuePair<Stat, dynamic> kvpTesting = new KeyValuePair<Stat, dynamic>(Stat.Damage, 100);
        }

        public void SetUpTowerCombat(BaseTowerSO test, GameObject towerRadiusReference)
        {
            localStatsDictionary = new Dictionary<Stat, dynamic>(test.StatsDictionary); //Copy dictionary as a new object, not reference
            hitPoints = test.StatsDictionary[Stat.HitPoints];
            targetTag = test.TowerInfo.targetTag;

            TEMPProjectile = test.TowerInfo.TEMPProjectile;
            TEMPProjectile.GetComponent<Projectile>().SetUp(damage, targetTag);
            towerRadius = towerRadiusReference;

            towerRadius.GetComponent<TowerRadiusTargetList>().ListUpdated += OnListUpdated;
            isSetUp = true;
        }

        //This function called from skill upgrades system
        //TODO : When adding save system, plan to call AlterStats
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
