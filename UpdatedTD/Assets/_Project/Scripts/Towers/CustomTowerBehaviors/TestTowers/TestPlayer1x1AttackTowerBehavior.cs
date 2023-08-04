using GenericObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestPlayer1x1AttackTowerBehavior : BaseTowerAttackHandler
    {
        public override void Attack(Transform target)
        {
            if (Time.time > nextAttackTime)
            {
                //TODO : Add in sound effects 
                nextAttackTime = Time.time + localStatsDictionary[Stat.AttackCooldown];
                ShootProjectile(localStatsDictionary[Stat.Projectile], target);
            }
        }

        //TODO : Could make bullets more customizable instead of handling the speed here...
        private void ShootProjectile(GameObject projectile, Transform target)
        {
            GameObject bullet = ObjectPoolHandler.SpawnObject(projectile, transform.position, transform.rotation, ObjectPoolHandler.PoolType.PlayerProjectiles);
            bullet.GetComponent<Projectile>().SetUp(localStatsDictionary[Stat.Damage], localStatsDictionary[Stat.TargetLayer]);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = (target.transform.position - transform.position).normalized;
                rb.AddForce(direction * localStatsDictionary[Stat.ProjectileSpeed], ForceMode.Impulse);
            }
        }
    }
}
