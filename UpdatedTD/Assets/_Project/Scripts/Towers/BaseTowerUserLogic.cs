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
        private bool inBuildState;

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


            towerAttackBehavior.SetUpLocalDictionary(towerInfo);
            towerAttackBehavior.SetUpTowerAttackParameters(towerInfo.TowerInfo, towerRadiusObject);
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

        public void ManualDestroyTower() 
        {
            //TODO : Make some currency back? how would this change if player upgrade the tower?
            Destroy(transform.parent.gameObject); 
        }

        //TODO : is this effective?
        public BaseTowerCombatHandler GetTowerAttackBehavior()
        {
            return towerAttackBehavior;
        }

        #region MouseFunctions
        private void OnMouseEnter()
        {
            Invoke("Blah", 0.5f);
            if (GameManager.Instance.State == GameManager.GameState.Building)
            {
                gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
            
        }

        private void OnMouseExit()
        {

        }

        private void OnMouseDown()
        {
            //If clicked on same object
            if (SelectionManager<BaseTowerUserLogic>.SelectedSameObject(this))
            {
                Debug.Log("haha");
            }
            //First time selecting or this is new selection
            else
            {
                towerRadiusObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        private void OnMouseUp()
        {
        }
        #endregion

        private void Blah()
        {
            gameObject.layer = LayerMask.NameToLayer("PlayerTowers");
        }
    }
}
