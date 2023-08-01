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
            Select();

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
            towerRadiusObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        public virtual void Deselect()
        {
            towerRadiusObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        public void ManualDestroyTower() 
        {
            //TODO : Make some currency back? how would this change if player upgrade the tower?
            Destroy(gameObject); 
        }

        //TODO : is this effective?
        public BaseTowerCombatHandler GetTowerAttackBehavior()
        {
            return towerAttackBehavior;
        }

        #region MouseFunctions
        private void OnMouseEnter()
        {
            if (!inBuildState)
            {
                gameObject.layer = LayerMask.NameToLayer("PlayerTowers");
                Select();
            }

            if (inBuildState) { gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); }
        }

        private void OnMouseExit()
        {
            gameObject.layer = LayerMask.NameToLayer("PlayerTowers");
        }

        private void OnMouseDown()
        {
            if (!inBuildState) 
            {
                gameObject.layer = LayerMask.NameToLayer("PlayerTowers");
                Select(); 
            }

            if (inBuildState) { gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); }
        }

        private void OnMouseUp()
        {
        }
        #endregion
    }
}
