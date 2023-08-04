using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [RequireComponent(typeof(BaseTowerAttackHandler))]
    public class TowerTargetingSystem : MonoBehaviour
    {
        [SerializeField] private float detectionRadius;
        [SerializeField] private LayerMask enemyLayer;

        private bool isSetUp;
        public void SetUp(float detectionRadius, LayerMask enemyLayer)
        {
            this.detectionRadius = detectionRadius;
            this.enemyLayer = enemyLayer;
            isSetUp = true;
        }

        public Transform DetectEnemies()
        {
            if (!isSetUp) { return null; }

            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

            if (colliders.Length > 0)
            {
                return colliders[0].transform; // Return the first detected collider
            }

            return null; // No enemies detected
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}
