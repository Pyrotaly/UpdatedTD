using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    //TODO : remove this self note later... this component on tower, UISkillTree will read from this skills to update the UI
    public class TestTower1Skills : MonoBehaviour
    {
        private BaseTowerCombatHandler tower;

        private Dictionary<int, Action> functionTopMap = new Dictionary<int, Action>();
        private Dictionary<int, Action> functionBotMap = new Dictionary<int, Action>();
        [HideInInspector] public int topCounter;
        [HideInInspector] public int botCounter;

        private KeyValuePair<Stat, dynamic> kvpTesting;

        private void Start()
        {
            tower = GetComponent<BaseTowerCombatHandler>();

            functionTopMap.Add(1, TopPathUpgrade1);
            functionTopMap.Add(2, TopPathUpgrade2);
            functionTopMap.Add(3, TopPathUpgrade3);

            functionBotMap.Add(1, BotPathUpgrade1);
            functionBotMap.Add(2, BotPathUpgrade2);
            functionBotMap.Add(3, BotPathUpgrade3);
        }

        public void UpgradeTopPath()
        {
            Debug.Log(topCounter);
            topCounter++;
            if (functionTopMap.TryGetValue(topCounter, out Action function)) { function.Invoke(); }
        }

        public void UpgradeBotPath()
        {
            botCounter++;
            if (functionBotMap.TryGetValue(botCounter, out Action function)) { function.Invoke(); }
        }

        //Stat increase damage
        private void TopPathUpgrade1()
        {
            kvpTesting = new KeyValuePair<Stat, dynamic>(Stat.Damage, 100);
            tower.AlterStats(kvpTesting);
        }
        //Stat increase projectile speed
        private void TopPathUpgrade2()
        {
            kvpTesting = new KeyValuePair<Stat, dynamic>(Stat.Projectile, 100);
            tower.AlterStats(kvpTesting);
        }
        //Stat increase health
        private void TopPathUpgrade3()
        {
            kvpTesting = new KeyValuePair<Stat, dynamic>(Stat.HitPoints, 100);
            tower.AlterStats(kvpTesting);
        }

        //Tower Change
        private void BotPathUpgrade1()
        {
            kvpTesting = new KeyValuePair<Stat, dynamic>(Stat.Damage, 100);
            tower.AlterStats(kvpTesting);
        }
        //Projectile Change
        private void BotPathUpgrade2()
        {
            var newProjectile = new GameObject();
            kvpTesting = new KeyValuePair<Stat, dynamic>(Stat.Projectile, newProjectile);
            tower.AlterStats(kvpTesting);
        }
        //Stat
        private void BotPathUpgrade3()
        {
            Dictionary<Stat, dynamic> testDict = new Dictionary<Stat, dynamic>();
            testDict.Add(Stat.Damage, 120);
            testDict.Add(Stat.AttackRange, 20);
            testDict.Add(Stat.HitPoints, 200);

            foreach (var x in testDict)
            {
                tower.AlterStats(x);
            }
        }
    }
}
