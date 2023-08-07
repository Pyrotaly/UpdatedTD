using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class EnemyLazerDamageTower : BaseTowerAttackHandler
    {
        //TODO : the lazer could be on projectile variable in the SO

        Ray ray;
        float maxDistance = 100;

        private void Start()
        {
            ray = new Ray(gameObject.transform.position, transform.forward);
        }

        public override void Attack(Transform target)
        {
            //TODO : have a lazer spawn spawn based on direction going....
            //check how it is moving along the z or x axis and set it accordingly
            LazerEndPointCollision();
            Debug.Log("haha");
        }

        private void LazerEndPointCollision()
        {
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, localStatsDictionary[Stat.TargetLayer]))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);
            }
        }
    }
}
