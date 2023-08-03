using GenericObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestSpawnTower : MonoBehaviour
    {
        public GameObject TestTower;
        public Transform TestTowerStartingPoint;

        public void Start()
        {
            //TODO : Set up rotation due to new art rotation, delete this entire script later...
            GameObject enemySpawn = ObjectPoolHandler.SpawnObject(TestTower, transform.position, transform.rotation, ObjectPoolHandler.PoolType.Enemies);
            enemySpawn.GetComponent<BaseTowerUserLogic>().CustomInitialize();
        }
    }
}
