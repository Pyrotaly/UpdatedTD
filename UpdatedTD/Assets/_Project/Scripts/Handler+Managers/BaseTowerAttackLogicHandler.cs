using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class BaseTowerAttackLogicHandler : MonoBehaviour
    {
        [SerializeField] private PlayerTowerInfoSO towerInfo;
        [SerializeField] private LayerMask enemyLayerMask;
        private List<GameObject> enemies = new List<GameObject>();

        private bool isInitialized = false;

        private void Awake()
        {
            transform.localScale = new Vector3(towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange);
        }

        public void Initialize()
        {
            isInitialized = true;
        }

        private void Update()
        {
            if (!isInitialized) { return; }

            //TODO : Right now turret just hits the first enemy that entered range, this is base class so downcasting later on they can have unique attacks
            if (enemies != null)
            {
                //hit first enemy in the list
                for (int i = 0; i < enemies.Count; i++)
                {
                    Debug.Log(enemies[i]);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D enemyThatEnteredRadius)
        {
            enemies.Add(enemyThatEnteredRadius.gameObject);
        }

        private void OnTriggerExit2D(Collider2D enemyThatEnteredRadius)
        {
            enemies.Remove(enemyThatEnteredRadius.gameObject);
        }
    }
}
