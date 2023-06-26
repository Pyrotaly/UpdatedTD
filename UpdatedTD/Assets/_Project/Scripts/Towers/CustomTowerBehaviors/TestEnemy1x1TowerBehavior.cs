using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestEnemy1x1TowerBehavior : BaseTowerAttackBehavior
    {
        //TODO : Need to setup tower becuase rn the targestlist is nothing on enemy since it not get reference to the child object list
        public override void Attack()
        {
            if (targetList.Count != 0)
            {
                foreach (GameObject i in targetList)
                {
                    Debug.Log(i + " Enemy Haha");
                }

                if (Time.time - lastShotTime >= attackCooldown)
                {
                    Debug.Log("DIE FROM ENEMY");
                    ShootProjectile(TEMPProjectile);
                    lastShotTime = Time.time;
                }
            }
        }

        private void ShootProjectile(GameObject prefab)
        {
            // Instantiate the projectile at the tower's position and rotation
            GameObject spawnedProjectile = Instantiate(prefab, transform.position, transform.rotation);

            // Get the Rigidbody component from the spawned projectile
            Rigidbody rb = spawnedProjectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = (targetList[0].transform.position - transform.position).normalized;
                rb.AddForce(direction * projectileSpeed, ForceMode.Impulse);
            }
        }
    }
}
