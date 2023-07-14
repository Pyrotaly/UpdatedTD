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
            base.Update();

            if (pathIndex == WIPLevelManager.Instance.GetPath.Length)
            {
                Destroy(gameObject);
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, WIPLevelManager.Instance.GetPath[pathIndex].position, towerSO.moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, WIPLevelManager.Instance.GetPath[pathIndex].position) < 0.01f)
            {
                pathIndex++;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "PlayerHealth")
            {
                Debug.Log("HAH");
                collision.GetComponent<IDamageable>().AlterCurrentHitPoints(towerSO.PlayerHealthDamage);
                Debug.Log(towerSO.PlayerHealthDamage);
            }
        }

        public override void Deselect()
        {
            base.Deselect();
        }

        public override void Select()
        {
            base.Select();
        }
    }
}
