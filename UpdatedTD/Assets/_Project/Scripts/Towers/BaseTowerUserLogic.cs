    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerUserLogic : MonoBehaviour, ISelectable
    {
        [SerializeField] protected BaseTowerSO towerInfo;

        private GameObject towerRadius;
        private BaseTowerCombatHandler towerAttackBehavior;
        private bool inBuildState;

        private void Awake()
        {
            GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
            towerRadius = GameAssetsHolderManager.Instance.TowerAttackHandler;   
            towerAttackBehavior = GetComponent<BaseTowerCombatHandler>();
        }

        private void OnDestroy()
        {
            GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
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
            var towerRadiusHandler = Instantiate(towerRadius, this.gameObject.transform);
            //Select();

            towerAttackBehavior.SetUpLocalDictionary(towerInfo);
            towerAttackBehavior.SetUpTowerAttackParameters(towerInfo.TowerInfo, towerRadiusHandler);
        }

        protected virtual void Update()
        {
            towerAttackBehavior.Attack();

            //TODO : Remove this testing
            KeyValuePair<Stat, dynamic> kvpTesting = new KeyValuePair<Stat, dynamic>(Stat.Damage, 100);


            //towerAttackBehavior.AlterStats(kvpTesting);
        }

        public virtual void Select()
        {
            towerRadius.SetActive(true);
        }

        public virtual void Deselect()
        {
            towerRadius.SetActive(false);
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
        }

        private void OnMouseExit()
        {
        }

        private void OnMouseDown()
        {
            if (!inBuildState) {
                Debug.Log("what");
                    Select(); }
        }

        private void OnMouseUp()
        {
        }
        #endregion


        private void GameManager_OnGameStateChanged(GameManager.GameState state)
        {
            inBuildState = (state == GameManager.GameState.Building);
        }
    }
}
