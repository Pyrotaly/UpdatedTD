using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerAttackingHandler : MonoBehaviour
    {
        private PlayerTowerInfoSO towerInfo;
        private SpriteRenderer spriteRenderer;

        [SerializeField] private LayerMask enemyLayerMask;
        private List<GameObject> enemies = new List<GameObject>();

        private bool isInitialized = false;

        //Make sure to Initialize this reference in TowerTile
        public void Initialize(PlayerTowerInfoSO towerInfo)
        {
            this.towerInfo = towerInfo;
            
            transform.localScale = new Vector3(towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange);
            spriteRenderer = GetComponent<SpriteRenderer>();
            DisableAttackRadius();

            isInitialized = true;
        }

        private void Update()
        {
            if (!isInitialized) { return; }

            //TODO : Right now turret just hits the first enemy that entered range 
            if (enemies != null)
            {
                //hit first enemy in the list
                for (int i = 0; i < enemies.Count; i++)
                {
                    Debug.Log(enemies[i]);
                }
            }
        }
        private void ShootProjectile()
        {

        }

        private void OnTriggerEnter2D(Collider2D enemyThatEnteredRadius)
        {
            enemies.Add(enemyThatEnteredRadius.gameObject);
        }

        private void OnTriggerExit2D(Collider2D enemyThatEnteredRadius)
        {
            enemies.Remove(enemyThatEnteredRadius.gameObject);
        }X

        public void EnableAttackRadius() { spriteRenderer.enabled = true; }

        public void DisableAttackRadius() { spriteRenderer.enabled = false; }
    }
}
