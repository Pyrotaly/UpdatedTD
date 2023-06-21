using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerTile : MonoBehaviour, ISelectable
    {
        [SerializeField] private PlayerTowerInfoSO towerInfo;
        private GameObject towerAttackRadius;

        private void Awake()
        {
            towerAttackRadius = GameAssetsHolderManager.Instance.AttackRadiusSprite;
        }

        private void Start()
        {
            towerAttackRadius.transform.localScale = new Vector3(towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange);
        }

        public PlayerTowerInfoSO GetTowerInfo()
        {
            return towerInfo;
        }

        public void Select()
        {
            //Play sound effect
            //Display description and stuff
            towerAttackRadius.SetActive(true);
        }

        public void Deselect()
        {
            towerAttackRadius.SetActive(false);
        }
    }
}
