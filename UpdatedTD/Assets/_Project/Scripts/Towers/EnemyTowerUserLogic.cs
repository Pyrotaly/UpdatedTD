using GenericObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class EnemyTowerUserLogic : BaseTowerUserLogic, ISlowable
    {
        private EnemyTowerInfoSO towerSO;
        private int pathIndex = 0;

        public float SpeedPercentageChange { get; set; }

        private void Start()
        {
            SpeedPercentageChange = 1f;
            towerSO = (EnemyTowerInfoSO)towerInfo;
        }

        protected virtual void Update()
        {
            #region HandleMoving
            if (pathIndex == LevelManager.Instance.GetPath1.Length)
            {
                ObjectPoolHandler.ReturnObjectToPool(gameObject);
                return;
            }

            gameObject.transform.parent.position = Vector3.MoveTowards(gameObject.transform.parent.position, LevelManager.Instance.GetPath1[pathIndex].position, 
                (towerSO.moveSpeed * SpeedPercentageChange) * Time.deltaTime);

            if (Vector3.Distance(gameObject.transform.parent.position, LevelManager.Instance.GetPath1[pathIndex].position) < 0.01f)
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

        protected override void Die()
        {
            ObjectPoolHandler.ReturnObjectToPool(transform.parent.gameObject);
        }
    }
}
