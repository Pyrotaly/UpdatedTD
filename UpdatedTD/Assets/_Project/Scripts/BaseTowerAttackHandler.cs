using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerAttackHandler : MonoBehaviour
    {
        [SerializeField] protected LayerMask enemyLayer;

        protected abstract void Fire();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            
        }
    }
}
