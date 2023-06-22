using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestPlayer1x1TowerBehavior : BaseTowerAttackHandler
    {
        public override void Attack(GameObject projectile)
        {
            if (targetList.Count != 0)
            {
                ShootProjectile(projectile);
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
                //rb.AddForce(direction * shootingForce, ForceMode.Impulse);
            }
        }
    }
}
