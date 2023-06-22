using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class Projectile : MonoBehaviour
    {
        private LayerMask targetLayer;
        private int damageAmount;

        public void SetUp(int damageSetUp, LayerMask targetSetUp)
        {
            targetLayer = targetSetUp;
            damageAmount = damageSetUp;
        }

        //2d sprite but 3d collider
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.layer == targetLayer)
            {
                collision.GetComponent<IDamageable>().AlterHealth(damageAmount);
                Destroy(this.gameObject);
            }
        }
    }
}
