using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class BaseEnemyClass : MonoBehaviour, IDamageable
    {
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private EnemyTowerInfoSO towerSO;
        private BaseTowerAttackBehavior towerAttackBehavior;
        private TowerRadiusTargetList towerRadius;

        private int pathIndex = 0;

        public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private void Awake()
        {
            towerRadius = GetComponentInChildren<TowerRadiusTargetList>();
            towerAttackBehavior = GetComponent<BaseTowerAttackBehavior>();
        }

        private void Start()
        {
            towerAttackBehavior.SetUpTowerAttackParameters(towerSO.TowerInfo, towerRadius.GetComponent<TowerRadiusTargetList>().targetList);
        }

 
        private void Update()
        {
            towerAttackBehavior.Attack();

            if (pathIndex == WIPLevelManager.Instance.GetPath.Length) 
            { 
                Destroy(gameObject);
                return;
            }

            transform.position = Vector2.MoveTowards(transform.position, WIPLevelManager.Instance.GetPath[pathIndex].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, WIPLevelManager.Instance.GetPath[pathIndex].position) < 0.1f)
            {
                pathIndex++;
            }
        }
    }
}
