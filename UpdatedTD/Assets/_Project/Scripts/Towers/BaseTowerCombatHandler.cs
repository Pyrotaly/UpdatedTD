using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerCombatHandler : MonoBehaviour, IDamageable
    {
        protected List<GameObject> targetList = new List<GameObject>();
        private GameObject towerRadius;

        protected int currentHP;
        protected int maxHP;

        protected Dictionary<Stat, dynamic> localStatsDictionary;

        protected GameObject TEMPProjectile;

        protected float nextAttackTime = 0f;
        public bool isSetUp = false;

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
            currentHP = localStatsDictionary[Stat.MaxHitpoints];

            TEMPProjectile = localStatsDictionary[Stat.Projectile];
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

                //If ugprading tower health, it will also heal it to max
                if (kvp.Key == Stat.MaxHitpoints)
                {
                    currentHP = localStatsDictionary[Stat.MaxHitpoints];
                }

                if (kvp.Key == Stat.AttackRange)
                {
                    float newRange = localStatsDictionary[Stat.AttackRange];
                    towerRadius.transform.localScale = new Vector3(newRange, newRange, newRange);
                }
            }
        }

        private void OnListUpdated(List<GameObject> updatedList) { targetList = updatedList; }

        private void OnDestroy()
        {
            towerRadius.GetComponent<TowerRadiusTargetList>().ListUpdated -= OnListUpdated;
        }

        public abstract void Attack();

        protected abstract void Die();

        public void AlterCurrentHitPoints(int hitPointAlterAmount)
        {
            //TODO : Die function
            currentHP += hitPointAlterAmount;

            if (currentHP <= 0) { Die(); }
        }
    }
}
