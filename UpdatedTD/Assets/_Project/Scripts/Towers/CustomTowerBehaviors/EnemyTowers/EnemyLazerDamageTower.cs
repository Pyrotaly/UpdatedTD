using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class EnemyLazerDamageTower : BaseTowerAttackHandler
    {
        //TODO : the lazer could be on projectile variable in the SO

        Ray ray1, ray2, ray3, ray4;
        private float maxDistance = 100;

        public float tickInterval = 1.0f;  // Interval between damage ticks
        public float damagePerTick = 10.0f;

        private IDamageable target1, target2, target3, target4;

        private void LazerMove()
        {
            ray1.origin = gameObject.transform.position;
            ray1.direction = transform.forward;
            ray2.origin = gameObject.transform.position;
            ray2.direction = transform.right;
            ray3.origin = gameObject.transform.position;
            ray3.direction = transform.forward * -1;
            ray4.origin = gameObject.transform.position;
            ray4.direction = transform.right * -1;

            LazerEndPointCollisionDebug(ray1);
            LazerEndPointCollisionDebug(ray2);
            LazerEndPointCollisionDebug(ray3);
            LazerEndPointCollisionDebug(ray4);
        }

        public override void Attack(Transform target)
        {
            LazerMove();
        }

        private void DealDamage(IDamageable target)
        {
            if (Time.time < nextAttackTime) { return; }
            target.AlterCurrentHitPoints(-localStatsDictionary[Stat.Damage]);
            nextAttackTime = Time.time + localStatsDictionary[Stat.AttackCooldown];
        }

        private void LazerEndPointCollisionDebug(Ray ray)
        {
            //If hit something
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, localStatsDictionary[Stat.TargetLayer]))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

                DealDamage(hit.collider.GetComponent<IDamageable>());
            }
            //else did not hit something
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);
            }
        }
    }
}
