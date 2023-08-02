using GenericObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestPlayer1x1AttackTowerBehavior : BaseTowerCombatHandler
    {
        public override void Attack()
        {
            if (targetList.Count != 0)
            {
                if (Time.time > nextAttackTime)
                {
                    nextAttackTime = Time.time + attackCooldown;
                    ShootProjectile(TEMPProjectile);
                }
            }
        }

        //TODO : Could make bullets more customizable instead of handling the speed here...
        private void ShootProjectile(GameObject prefab)
        {
            GameObject bullet = ObjectPoolHandler.SpawnObject(prefab, transform.position, transform.rotation, ObjectPoolHandler.PoolType.PlayerProjectiles);
            bullet.GetComponent<Projectile>().SetUp(damage, targetTag);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = (targetList[0].transform.position - transform.position).normalized;
                rb.AddForce(direction * projectileSpeed, ForceMode.Impulse);
            }
        }
    }
}
