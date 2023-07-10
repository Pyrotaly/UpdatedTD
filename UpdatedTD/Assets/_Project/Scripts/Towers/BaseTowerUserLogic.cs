    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerUserLogic : MonoBehaviour, ISelectable, IDamageable
    {
        [SerializeField] protected BaseTowerSO towerInfo;
        public float Health { get { return towerInfo.TowerInfo.Health; } set { } }

        private GameObject towerRadius;
        private BaseTowerAttackBehavior towerAttackBehavior;

        private void Awake()
        {
            towerRadius = GameAssetsHolderManager.Instance.TowerAttackHandler;   
            towerAttackBehavior = GetComponent<BaseTowerAttackBehavior>();
        }

        //TODO : TESTING FUNCTION CallStart, used on Test Spawn Enemy to test 
        public void TEMPCallStart()
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
            if (SelectionManager<BaseTowerUserLogic>.previousSelectedObject == null)
            {
                towerRadius.SetActive(true);
                return;
            }

            if (SelectionManager<BaseTowerUserLogic>.SelectedSameObject(this))
            {
                //If clicked on same tower
                //Do nothing or can disable ui...
            }
            else
            {
                //If this new tower player clicked on is not same then do then enable the description
                towerRadius.SetActive(true);
            }

        }

        public virtual void Deselect()
        {
            towerRadius.SetActive(false);
            Debug.Log("Deselected " + SelectionManager<BaseTowerUserLogic>.previousSelectedObject.name);
        }

        public void DestroyTower() 
        {
            //TODO : Make some currency back? how would this change if player upgrade the tower?
            Destroy(gameObject); 
        }

        public void AlterHealth(float healthAlterAmount)
        {
            Health += healthAlterAmount;
        }

        #region MouseFunctions
        private void OnMouseEnter()
        {
        }

        private void OnMouseExit()
        {
        }

        private void OnMouseDown()
        {
            Select();
        }

        private void OnMouseUp()
        {
        }
        #endregion
    }
}
