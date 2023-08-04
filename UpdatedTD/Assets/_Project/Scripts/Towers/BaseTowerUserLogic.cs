    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerUserLogic : MonoBehaviour, ISelectable, IDamageable
    {
        [SerializeField] protected BaseTowerSO towerInfo;

        public BaseTowerAttackHandler[] towerAttackBehavior;
        private List<SpriteRenderer> towerTargetSpriteRenderer = new List<SpriteRenderer>();

        private int currentHP;
        private Dictionary<Stat, dynamic> localStatsDictionary;

        private void Awake()
        {
            towerAttackBehavior = transform.parent.GetComponentsInChildren<BaseTowerAttackHandler>();
            
            //TODO : Need to add visual that shows tower target radius with that wiresphere mesh i serached
            //foreach (BaseTowerAttackHandler attackHandler in towerAttackBehavior)
            //{
            //    towerTargetSpriteRenderer.Add(attackHandler.gameObject.GetComponent<SpriteRenderer>());
            //}

            localStatsDictionary = new Dictionary<Stat, dynamic>(towerInfo.StatsDictionary);
        }

        private void Start()
        {
            CustomInitialize();

            //Player towers will call OnMouseDown, enemey towers don't call start on instantiation
            OnMouseDown();
        }

        public void CustomInitialize()
        {
            currentHP = localStatsDictionary[Stat.MaxHitpoints];
            foreach (BaseTowerAttackHandler attackHandler in towerAttackBehavior) { attackHandler.SetUpTowerCombat(localStatsDictionary); }
        }

        //This function called from skill upgrades system
        //TODO : When adding save system, plan to call AlterStats
        public void AlterStats(params KeyValuePair<Stat, dynamic>[] pair)
        {
            foreach (KeyValuePair<Stat, dynamic> kvp in pair)
            {
                if (localStatsDictionary.ContainsKey(kvp.Key)) { localStatsDictionary[kvp.Key] = kvp.Value; }

                //If ugprading tower health, it will also heal it to max
                if (kvp.Key == Stat.MaxHitpoints) { currentHP = localStatsDictionary[Stat.MaxHitpoints]; }
            }

            foreach (BaseTowerAttackHandler attackHandler in towerAttackBehavior) { attackHandler.SetUpTowerCombat(localStatsDictionary); }
        }

        public virtual void Select()
        {
            //foreach (SpriteRenderer spriteRenderer in towerTargetSpriteRenderer) { spriteRenderer.enabled = true; }
        }

        public virtual void Deselect()
        {
            //foreach (SpriteRenderer spriteRenderer in towerTargetSpriteRenderer) { spriteRenderer.enabled = false; }
        }

        private void RevertTowerLayer()
        {
            gameObject.layer = LayerMask.NameToLayer("PlayerTowers");
        }

        protected abstract void Die();

        public void AlterCurrentHitPoints(int hitPointAlterAmount)
        {
            currentHP += hitPointAlterAmount;

            if (currentHP <= 0) { Die(); }
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
                Select();
            }
        }
        #endregion
    }
}
