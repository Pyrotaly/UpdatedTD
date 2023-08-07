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
        [SerializeField] private GameObject wireIndicatorObject;

        public Collider[] enemyList;

        private bool isSetUp;

        public void SetUp(float detectionRadius, LayerMask enemyLayer)
        {
            this.detectionRadius = detectionRadius;
            this.enemyLayer = enemyLayer;
            wireIndicatorObject.transform.localScale = new Vector3(detectionRadius, detectionRadius, detectionRadius);
            isSetUp = true;
        }

        public Transform DetectEnemies()
        {
            if (!isSetUp) { return null; }

            enemyList = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
            Debug.Log(enemyList.Length);

            //foreach (Collider collisions in colliders)
            //{
            //    Debug.Log(collisions.gameObject.transform.parent.name);
            //}

            if (enemyList.Length > 0)
            {
                return enemyList[0].transform; // Return the first detected collider
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
