using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameState State;

        public static event Action<GameState> OnGameStateChanged;

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

        private void Start()
        {
            UpdateGameState(GameState.Play);
        }

        public void UpdateGameState(GameState newState)
        {
            State = newState;

            switch (newState)
            {
                case GameState.Pause:
                    break;
                case GameState.Building:
                    break;
                case GameState.Play:
                    break;
                case GameState.Map:
                    break;
                case GameState.Victory:
                    break;
                case GameState.GameOver:
                    Debug.Log("loss");
                    break;
                default:
                    break;
            }

            OnGameStateChanged?.Invoke(newState);
        }

        private void HandleBuildState()
        {
            //if press escape than resume back to play mode
        }

        public enum GameState
        {
            Pause,
            Building,
            Play, //When the player just let the game running and play on its own
            Map,
            Victory,
            GameOver
        }
    }
}