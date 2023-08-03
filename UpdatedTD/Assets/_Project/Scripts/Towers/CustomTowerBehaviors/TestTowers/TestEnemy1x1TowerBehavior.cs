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
            if (Time.time > nextAttackTime)
            {

                if (targetList.Count != 0)
                {
                    if (targetList[0] == null)
                    {
                        targetList.Clear();
                        return;
                    }

                    nextAttackTime = Time.time + localStatsDictionary[Stat.AttackCooldown];
                    var targetPos = targetList[0].transform.position;
                    ShootProjectile(TEMPProjectile, targetPos);
                }
            }
        }

        protected override void Die()
        {
            ObjectPoolHandler.ReturnObjectToPool(gameObject);
        }

        //TODO : Could make bullets more customizable instead of handling the speed here...
        private void ShootProjectile(GameObject prefab, Vector3 position)
        {
            GameObject bullet = ObjectPoolHandler.SpawnObject(prefab, transform.position, transform.rotation, ObjectPoolHandler.PoolType.EnemyProjectiles);
            //bullet.GetComponent<Projectile>().SetUp(damage, targetTag);

            bullet.GetComponent<Projectile>().SetUp(localStatsDictionary[Stat.Damage], localStatsDictionary[Stat.TargetTag]);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                if (targetList[0] == null) { Debug.Log("ja"); }

                Vector3 direction = (position - transform.position).normalized;
                rb.AddForce(direction * localStatsDictionary[Stat.ProjectileSpeed], ForceMode.Impulse);
            }
        }
    }
}
