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

        private void OnEnable()
        {
            ActionsHolder.OnEnemyKilled += OnEnemyDeath;
        }

        private void OnDisable()
        {
            ActionsHolder.OnEnemyKilled -= OnEnemyDeath;
        }

        private void OnEnemyDeath()
        {
            enemiesAlive--;
            if (enemiesAlive == 0 && enemiesLeftToSpawn == 0) { StartWave(); }
        }

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
            //TODO : FINISH THIS
            //inbstead of transform.position, need to pick where to spawn...
            GameObject prefabToSpawn = enemyPrefabs[0];
            GameObject enemySpawn = ObjectPoolHandler.SpawnObject(prefabToSpawn, transform.position, transform.rotation, ObjectPoolHandler.PoolType.Enemies);
            enemySpawn.GetComponentInChildren<BaseTowerUserLogic>().CustomInitialize();

            //TODO : This is strange here?
            enemySpawn.GetComponentInChildren<BaseTowerUserLogic>().Deselect();
        }

        private void StartWave()
        {
            isSpawning = true;
            enemiesLeftToSpawn = EnemiesPerWave();
            currentWave++;
        }

        private int EnemiesPerWave()
        {
            return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficulityScalingFactor));
        }
    }
}
