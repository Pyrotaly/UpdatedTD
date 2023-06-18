using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class GameUIManager : MonoBehaviour
    {
        [Header("Main UI")]
        [SerializeField] private GameObject pauseUI; //TODO : Pause UI need to have button to get back to play or just never hide pause button
        [SerializeField] private GameObject shopUI;
        [SerializeField] private GameObject pauseButtonUI;
        [SerializeField] private GameObject[] otherButtonsUI;
        [SerializeField] private GameObject miniMapUI;
        [SerializeField] private GameObject[] currencyUI;

        [Header("End Game UI")]
        [SerializeField] private GameObject victoryScreen;
        [SerializeField] private GameObject defeatScreen;

        private void Awake()
        {
            GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
        }

        private void GameManager_OnGameStateChanged(GameManager.GameState state)
        {
            pauseUI.SetActive(state == GameManager.GameState.Pause);

            //When game start to be in play mode
            if (state == GameManager.GameState.Play)
            {
                shopUI.SetActive(true);
                foreach (GameObject buttonUI in otherButtonsUI) { buttonUI.SetActive(true); }
                miniMapUI.SetActive(true);
                foreach (GameObject currencyUI in currencyUI) { currencyUI.SetActive(true); }
            }

            if (state == GameManager.GameState.Building)
            {
                shopUI.SetActive(false);
                foreach (GameObject buttonUI in otherButtonsUI) { buttonUI.SetActive(false); }
                miniMapUI.SetActive(false);
                foreach (GameObject currencyUI in currencyUI) { currencyUI.SetActive(false); }
            }

            victoryScreen.SetActive(state == GameManager.GameState.Victory);
            defeatScreen.SetActive(state == GameManager.GameState.GameOver);
        }
    }
}
