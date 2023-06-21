using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerTile : MonoBehaviour, ISelectable
    {
        [SerializeField] private PlayerTowerInfoSO towerInfo;
        private GameObject towerAttackRadiusGameObject;

        private void Awake()
        {
            towerAttackRadiusGameObject = GameAssetsHolderManager.Instance.AttackRadius;
        }

        private void Start()
        {
            Debug.Log("Ha");
            towerAttackRadiusGameObject.transform.localScale = new Vector3(towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange);
            Instantiate(towerAttackRadiusGameObject, this.gameObject.transform);
        }

        private void Update()
        {
            //TODO : Shoot
        }

        public PlayerTowerInfoSO GetTowerInfo() { return towerInfo; }

        public void Select()
        {
            //Play sound effect
            //Display description and stuff
            towerAttackRadiusGameObject.SetActive(true);
        }

        public void Deselect()
        {
            towerAttackRadiusGameObject.SetActive(false);
        }
    }
}
