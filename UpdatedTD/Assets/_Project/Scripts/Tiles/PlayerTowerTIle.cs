using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class PlayerTowerTIle : MonoBehaviour, ISelectable, IDamageable
    {
        [SerializeField] private PlayerTowerInfoSO towerInfo;
        private GameObject towerRadius;
        private BaseTowerAttackBehavior towerAttackBehavior;

        public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private void Awake()
        {
            towerRadius = GameAssetsHolderManager.Instance.TowerAttackHandler;
            towerAttackBehavior = GetComponent<BaseTowerAttackBehavior>();
        }

        private void Start()
        {
            towerRadius.transform.localScale = new Vector3(towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange);
            towerRadius.GetComponent<TowerRadiusTargetList>().SetUp(towerInfo.TowerInfo.targetLayer);
            Instantiate(towerRadius, this.gameObject.transform);

            towerAttackBehavior.SetUpTowerAttackParameters(towerInfo.TowerInfo, towerRadius.GetComponent<TowerRadiusTargetList>().targetList);
        }

        private void Update()
        {
            towerAttackBehavior.Attack();
        }

        public PlayerTowerInfoSO GetTowerInfo() { return towerInfo; }

        public void Select()
        {
            //Play sound effect
            //Display description and stuff
            towerRadius.SetActive(true);
        }

        public void Deselect()
        {
            towerRadius.SetActive(false);
        }
    }
}
