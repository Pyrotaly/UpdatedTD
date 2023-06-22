using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerTile : MonoBehaviour, ISelectable
    {
        [SerializeField] private PlayerTowerInfoSO towerInfo;
        private GameObject towerAttackHandler;

        private void Awake()
        {
            towerAttackHandler = GameAssetsHolderManager.Instance.TowerAttackHandler;
        }

        private void Start()
        {
            Debug.Log("Ha");
            towerAttackHandler.transform.localScale = new Vector3(towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange);
            Instantiate(towerAttackHandler, this.gameObject.transform);
        }

        private void Update()
        {
            //towerAttackHandler.GetComponent<BaseTowerAttackHandler>().Attack(towerInfo.TowerInfo.TEMPProjectile);
        }

        public PlayerTowerInfoSO GetTowerInfo() { return towerInfo; }

        public void Select()
        {
            //Play sound effect
            //Display description and stuff
            towerAttackHandler.SetActive(true);
        }

        public void Deselect()
        {
            towerAttackHandler.SetActive(false);
        }
    }
}
