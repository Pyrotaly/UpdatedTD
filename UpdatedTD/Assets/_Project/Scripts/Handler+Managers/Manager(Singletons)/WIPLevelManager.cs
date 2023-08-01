using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class WIPLevelManager : MonoBehaviour
    {
        public Transform startpoint { get; private set; }

        [SerializeField] private Transform[] path;
        public Transform[] GetPath { get { return path;  } }


        private int WaveNumber;


        public static WIPLevelManager Instance;

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
