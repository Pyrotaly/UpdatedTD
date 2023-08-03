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
            
            if (Time.time > nextAttackTime)
            {
                if (targetList.Count != 0)
                {
                    nextAttackTime = Time.time + localStatsDictionary[Stat.AttackCooldown];
                    ShootProjectile(TEMPProjectile);
                }
            }
        }

        protected override void Die()
        {
            Destroy(transform.parent.gameObject);
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
