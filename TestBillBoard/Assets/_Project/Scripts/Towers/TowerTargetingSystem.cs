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
            this.enemyLayer = enemyLayer;                               //TODO : This '1' here could change...
            wireIndicatorObject.transform.localScale = new Vector3(detectionRadius, 1, detectionRadius);
            isSetUp = true;
        }

        public Transform DetectEnemies()
        {
            if (!isSetUp) { return null; }

            enemyList = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

            if (enemyList.Length > 0)
            {
                return enemyList[0].transform;
            }

            return null;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}
