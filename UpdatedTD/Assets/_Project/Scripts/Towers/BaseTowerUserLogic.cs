    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerUserLogic : MonoBehaviour, ISelectable
    {
        [SerializeField] protected BaseTowerSO towerInfo;

        private GameObject towerRadius;
        private GameObject towerRadiusObject;
        private BaseTowerCombatHandler towerAttackBehavior;

        private void Awake()
        {
            towerRadius = GameAssetsHolderManager.Instance.TowerAttackHandler;
            towerAttackBehavior = GetComponent<BaseTowerCombatHandler>();
        }

        //TODO : TESTING FUNCTION CallStart, used on Test Spawn Enemy to test 
        public void TEMPCallStart()
        {
            Start();
        }

        private void Start()
        {
            //Spawn tower radius
            towerRadius.transform.localScale = new Vector3(towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange, towerInfo.TowerInfo.AttackRange);
            towerRadius.GetComponent<TowerRadiusTargetList>().SetUp(towerInfo.TowerInfo.targetTag);
            towerRadiusObject = Instantiate(towerRadius, this.gameObject.transform);
            OnMouseDown();

            towerAttackBehavior.SetUpTowerCombat(towerInfo, towerRadiusObject);
        }

        protected virtual void Update()
        {
            towerAttackBehavior.Attack();

            //TODO : Remove this testing
            KeyValuePair<Stat, dynamic> kvpTesting = new KeyValuePair<Stat, dynamic>(Stat.Damage, 100);
        }

        public virtual void Select()
        {
            //towerRadiusObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        public virtual void Deselect()
        {
            towerRadiusObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        private void RevertTowerLayer()
        {
            gameObject.layer = LayerMask.NameToLayer("PlayerTowers");
        }

        #region MouseFunctions
        //TODO : Do enemies need this features as well?
        private void OnMouseEnter()
        {
            Invoke("RevertTowerLayer", 0.5f);
            if (GameManager.Instance.State == GameManager.GameState.Building)
            {
                gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
            
        }

        private void OnMouseDown()
        {
            //If clicked on same object
            if (SelectionManager<BaseTowerUserLogic>.SelectedSameObject(this))
            {
            }
            //First time selecting or this is new selection
            else
            {
                towerRadiusObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        #endregion
    }
}
