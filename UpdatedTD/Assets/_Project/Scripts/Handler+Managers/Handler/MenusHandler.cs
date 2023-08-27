using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class MenusHandler : MonoBehaviour
    {
        [Header("Main UI")]
        [SerializeField] private GameObject pauseScreen; //TODO : Pause UI need to have button to get back to play or just never hide pause button
        [SerializeField] private GameObject optionsScreen; 
        [SerializeField] private GameObject shopUI;
        [SerializeField] private GameObject moreInfoUI;
        [SerializeField] private GameObject upgradeUI;
        [SerializeField] private GameObject informationUI;

        //Not sure what this is below
        [SerializeField] private GameObject[] otherNotPauseButtonsUI;

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

        public void EnableMoreInfoUI()
        {
            moreInfoUI.SetActive(true);
        }

        public void DisableMoreInfoUI()
        {
            moreInfoUI.SetActive(false);
            upgradeUI.SetActive(false);
            informationUI.SetActive(true);
        }

        private void GameManager_OnGameStateChanged(GameManager.GameState state)
        {
            //pauseScreen.SetActive(state == GameManager.GameState.Pause);

            //When game start to be in play mode
            if (state == GameManager.GameState.Play)
            {
                pauseScreen.SetActive(false);
                shopUI.SetActive(true); //TODO : Should enable shop again or no?
                foreach (GameObject buttonUI in otherNotPauseButtonsUI) { buttonUI.SetActive(true); }
            }

            if (state == GameManager.GameState.Pause)
            {
                pauseScreen.SetActive(true); //TODO : Should enable shop again or no?
                foreach (GameObject buttonUI in otherNotPauseButtonsUI) { buttonUI.SetActive(true); }
            }

            if (state == GameManager.GameState.Building)
            {
                shopUI.SetActive(false);
                moreInfoUI.SetActive(false);
                foreach (GameObject buttonUI in otherNotPauseButtonsUI) { buttonUI.SetActive(false); }
            }

            //victoryScreen.SetActive(state == GameManager.GameState.Victory);
            //defeatScreen.SetActive(state == GameManager.GameState.GameOver);
        }
    }
}
