using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class Projectile : MonoBehaviour
    {
        private string targetTag;
        private int damageAmount;

        public void SetUp(int damageSetUp, string targetSetUp)
        {
            targetTag = targetSetUp;
            damageAmount = damageSetUp;
        }

        //2d sprite but 3d collider
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == targetTag)
            {
                Debug.Log("AGH");
                collision.GetComponent<IDamageable>().AlterHealth(damageAmount);
                Destroy(this.gameObject);
            }
        }
    }
}
