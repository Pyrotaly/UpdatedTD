using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [RequireComponent(typeof(TowerTargetingSystem))]
    public abstract class BaseTowerAttackHandler : MonoBehaviour
    {
        protected Dictionary<Stat, dynamic> localStatsDictionary;
        protected float nextAttackTime;

        private TowerTargetingSystem towerRadius;
        private bool isSetUp = false;

        private void Awake()
        {
            towerRadius = GetComponent<TowerTargetingSystem>();
        }

        private void Update()
        {
            //TODO : idk if setup check does anything....
            if (!isSetUp) { return; }
            Transform target = towerRadius.DetectEnemies();

            if (target == null) { return; }
            Attack(target);
        }

        public void SetUpTowerCombat(Dictionary<Stat, dynamic> UserLogicDictionary)
        {
            localStatsDictionary = UserLogicDictionary;
            towerRadius.SetUp(localStatsDictionary[Stat.AttackRange], localStatsDictionary[Stat.TargetLayer]);

            isSetUp = true;
        }

        public abstract void Attack(Transform target);
    }
}
