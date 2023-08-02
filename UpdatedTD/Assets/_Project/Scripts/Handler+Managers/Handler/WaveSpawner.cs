using GenericObjectPooling;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class WaveSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject[] enemyPrefabs;

        [Header("Attributes")]
        [SerializeField] private int baseEnemies = 8;
        [SerializeField] private float enemiesPerSecond = 0.5f;
        [SerializeField] private float timeBetweenWaves = 5f;
        [SerializeField] private float difficulityScalingFactor = 0.75f;

        private int currentWave = 1;
        private float timeSinceLastSpawn;
        private int enemiesAlive;
        private int enemiesLeftToSpawn;
        private bool isSpawning = false;

        //TODO : Start wave if player does somthing
        private void Start()
        {
            StartWave();
        }

        private void Update()
        {
            if (!isSpawning) return;

            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
            {
                SpawnEnemy();
                enemiesLeftToSpawn--;
                enemiesAlive++;
                timeSinceLastSpawn = 0f;
            }
        }

        private void SpawnEnemy()
        {
            GameObject prefabToSpawn = enemyPrefabs[0];
            GameObject enemySpawn = ObjectPoolHandler.SpawnObject(prefabToSpawn, transform.position, transform.rotation, ObjectPoolHandler.PoolType.Enemies);
        }

        private void StartWave()
        {
            isSpawning = true;
            enemiesLeftToSpawn = EnemiesPerWave();
        }

        private int EnemiesPerWave()
        {
            return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficulityScalingFactor));
        }
    }
}
