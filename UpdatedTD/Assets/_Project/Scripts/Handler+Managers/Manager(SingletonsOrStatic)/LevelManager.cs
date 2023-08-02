using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class LevelManager : MonoBehaviour
    {
        public Transform Startpoint { get; private set; }

        [SerializeField] private Transform[] path1;
        [SerializeField] private Transform[] path2;
        public Transform[] GetPath1 { get { return path1;  } }
        public Transform[] GetPath2 { get { return path2;  } }

        private int WaveNumber;

        public static LevelManager Instance;

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
            //TODO : Idk
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //TODO : If finished final wave then game manaer set gamestate to victory
        private void StartWave()
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Building);
        }
    }
}
