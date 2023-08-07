using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class EnemyLazerDamageTower : BaseTowerAttackHandler
    {
        //TODO : the lazer could be on projectile variable in the SO

        Ray ray1, ray2, ray3, ray4;
        float maxDistance = 100;

        private void Start()
        {
            ray1 = new Ray(gameObject.transform.position, transform.forward);
        }

        public override void Attack(Transform target)
        {
            ray1.origin = gameObject.transform.position;
            ray1.direction = transform.forward; 
            ray2.origin = gameObject.transform.position;
            ray2.direction = transform.right;    
            ray3.origin = gameObject.transform.position;
            ray3.direction = transform.forward * -1;
            ray4.origin = gameObject.transform.position;
            ray4.direction = transform.right * -1;

            LazerEndPointCollision(ray1);
            LazerEndPointCollision(ray2);
            LazerEndPointCollision(ray3);
            LazerEndPointCollision(ray4);
        }

        private void LazerEndPointCollision(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, localStatsDictionary[Stat.TargetLayer]))
            {
                Debug.Log("Haha");
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);
            }
        }
    }
}
