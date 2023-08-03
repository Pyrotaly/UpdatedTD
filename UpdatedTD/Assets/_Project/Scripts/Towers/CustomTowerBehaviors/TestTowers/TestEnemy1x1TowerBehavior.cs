using GenericObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestEnemy1x1TowerBehavior : BaseTowerCombatHandler
    {
        //TODO : Need to setup tower becuase rn the targestlist is nothing on enemy since it not get reference to the child object list
        public override void Attack()
        {
            if (targetList.Count != 0)
            {
                if (Time.time > nextAttackTime)
                {
                    nextAttackTime = Time.time + localStatsDictionary[Stat.AttackCooldown];
                    ShootProjectile(TEMPProjectile);
                }
            }
        }

        //TODO : Could make bullets more customizable instead of handling the speed here...
        private void ShootProjectile(GameObject prefab)
        {
            GameObject bullet = ObjectPoolHandler.SpawnObject(prefab, transform.position, transform.rotation, ObjectPoolHandler.PoolType.PlayerProjectiles);
            //bullet.GetComponent<Projectile>().SetUp(damage, targetTag);

            bullet.GetComponent<Projectile>().SetUp(localStatsDictionary[Stat.Damage], localStatsDictionary[Stat.TargetTag]);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = (targetList[0].transform.position - transform.position).normalized;
                rb.AddForce(direction * localStatsDictionary[Stat.ProjectileSpeed], ForceMode.Impulse);
            }
        }
    }
}
