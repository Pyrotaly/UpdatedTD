    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerUserLogic : MonoBehaviour, ISelectable, IDamageable
    {
        [SerializeField] protected BaseTowerSO towerInfo;

        [SerializeField] private BaseTowerAttackHandler[] towerAttackBehavior;
        [SerializeField] private List<GameObject> towerTargetWireObject = new();

        private int currentHP;
        private Dictionary<Stat, dynamic> localStatsDictionary;

        private void Awake()
        {
            towerAttackBehavior = transform.parent.GetComponentsInChildren<BaseTowerAttackHandler>();
            //WireIndicator
            //TODO : Need to add visual that shows tower target radius with that wiresphere mesh i serached

            if (towerTargetWireObject.Count == 0) { Debug.LogError("Need to add in wireReferences in " + gameObject.name); }

            localStatsDictionary = new Dictionary<Stat, dynamic>(towerInfo.StatsDictionary);
        }

        private void Start()
        {
            CustomInitialize();

            //Player towers will call OnMouseDown, enemey towers don't call start on instantiation
            Select();
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
            //foreach (GameObject wireIndicator in towerTargetWireObject) { wireIndicator.SetActive(true); }
        }

        public virtual void Deselect()
        {
            foreach (GameObject wireIndicator in towerTargetWireObject) { wireIndicator.SetActive(false); }
        }

        protected abstract void Die();

        public void AlterCurrentHitPoints(int hitPointAlterAmount)
        {
            currentHP += hitPointAlterAmount;

            if (currentHP < 0) { Die(); }
        }
    }
}
