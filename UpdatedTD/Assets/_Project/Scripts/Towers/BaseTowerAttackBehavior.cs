using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerAttackBehavior : MonoBehaviour
    {
        protected List<GameObject> targetList;

        private int damage;
        protected float projectileSpeed;
        protected float attackCooldown;
        protected GameObject TEMPProjectile;
        private LayerMask targetLayer;

        protected float lastShotTime = 0f;

        public void SetUpTowerAttackParameters(TowerInfoStruct towerStruct, List<GameObject> list)
        {
            damage = towerStruct.Damage;
            projectileSpeed = towerStruct.ProjectileSpeed;
            attackCooldown = towerStruct.AttackCooldown;
            TEMPProjectile = towerStruct.TEMPProjectile;
            targetLayer = towerStruct.targetLayer;
            TEMPProjectile.GetComponent<Projectile>().SetUp(damage, targetLayer);
            targetList = list;
        }

        //TODO : GameObject parameter might not be ideal in future
        public abstract void Attack();
    }
}
