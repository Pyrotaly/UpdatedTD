using GenericObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class EnemyTowerUserLogic : BaseTowerUserLogic
    {
        private EnemyTowerInfoSO towerSO;
        private int pathIndex = 0;

        private void Start()
        {
            towerSO = (EnemyTowerInfoSO)towerInfo;
        }

        protected override void Update()
        {
            #region HandleMoving
            if (pathIndex == LevelManager.Instance.GetPath1.Length)
            {
                Destroy(gameObject);
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, LevelManager.Instance.GetPath1[pathIndex].position, towerSO.moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, LevelManager.Instance.GetPath1[pathIndex].position) < 0.01f)
            {
                pathIndex++;
            }
            #endregion
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "PlayerHealth")
            {
                collision.GetComponent<IDamageable>().AlterCurrentHitPoints(towerSO.PlayerHealthDamage);
                ObjectPoolHandler.ReturnObjectToPool(gameObject);
            }
        }
    }
}
