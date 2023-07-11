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
            Debug.Log(targetTag);
            //TODO : VS telling me there is a more efficient way to compare tag but it lead to errors...
            if (collision.gameObject.CompareTag(targetTag))
            {
                collision.GetComponent<IDamageable>().AlterHealth(-damageAmount);
                ObjectPoolHandler.ReturnObjectToPool(gameObject);
            }
        }
    }
}
