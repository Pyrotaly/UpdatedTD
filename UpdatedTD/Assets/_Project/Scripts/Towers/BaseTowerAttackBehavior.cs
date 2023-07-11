using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerAttackBehavior : MonoBehaviour
    {
        protected List<GameObject> targetList = new List<GameObject>();
        private GameObject towerRadius;

        private int damage;
        protected float projectileSpeed;
        protected float attackCooldown;
        protected GameObject TEMPProjectile;
        private string targetTag;


        protected float nextAttackTime = 0f;

        public void SetUpTowerAttackParameters(TowerInfoStruct towerStruct, GameObject towerRadiusReference)
        {
            damage = towerStruct.Damage;
            projectileSpeed = towerStruct.ProjectileSpeed;
            attackCooldown = towerStruct.AttackCooldown;
            TEMPProjectile = towerStruct.TEMPProjectile;
            targetTag = towerStruct.targetTag;
            TEMPProjectile.GetComponent<Projectile>().SetUp(damage, targetTag);
            towerRadius = towerRadiusReference;

            towerRadius.GetComponent<TowerRadiusTargetList>().ListUpdated += OnListUpdated;
        }

        private void OnListUpdated(List<GameObject> updatedList) { targetList = updatedList; }

        private void OnDestroy()
        {
            towerRadius.GetComponent<TowerRadiusTargetList>().ListUpdated -= OnListUpdated;
        }

        public abstract void Attack();
    }
}
