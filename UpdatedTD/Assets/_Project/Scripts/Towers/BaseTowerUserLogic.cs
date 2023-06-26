    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerUserLogic : MonoBehaviour, ISelectable, IDamageable
    {
        [SerializeField] protected BaseTowerSO towerInfo;
        private GameObject towerRadius;
        private BaseTowerAttackBehavior towerAttackBehavior;

        public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private void Awake()
        {
            towerRadius = GameAssetsHolderManager.Instance.TowerAttackHandler;  
            towerAttackBehavior = GetComponent<BaseTowerAttackBehavior>();
        }

        //TODO : TESTING FUNCTION CallStart, used on Test Spawn Enemy to test 
        public void CallStart()
        {
            Start();
        }

        private void Start()
        {
            towerRadius.transform.localScale = new Vector3(towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange);
            towerRadius.GetComponent<TowerRadiusTargetList>().SetUp(towerInfo.TowerInfo.targetTag);
            var towerRadiusHandler = Instantiate(towerRadius, this.gameObject.transform);

            towerAttackBehavior.SetUpTowerAttackParameters(towerInfo.TowerInfo, towerRadiusHandler);
        }

        protected virtual void Update()
        {
            towerAttackBehavior.Attack();
        }

        public virtual void Select()
        {
            towerRadius.SetActive(true);
        }

        public virtual void Deselect()
        {
            towerRadius.SetActive(false);
        }
    }
}
