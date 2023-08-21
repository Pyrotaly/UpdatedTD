using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GenericSave;
using UnityEngine.SceneManagement;

namespace UpdatedTD
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button newGameButton, continueGameButton;

        private void Start()
        {
            if (!DataPersistenceManager.instance.HasGameData())
            {
                continueGameButton.interactable = false;
            }
        }

        public void NewGame()
        {
            DisableMenuButtons();
            // create a new game which will initialize our game data
            DataPersistenceManager.instance.NewGame();
            // load gameplay scene, in turn save game because of OnSceneUnloaded() in persistencemanager
            SceneManager.LoadSceneAsync("NewPrototype"); //TODO : Change this string to the be the correct scene in final build
        }

        public void ContinueGame()
        {
            DisableMenuButtons();
            //Load next scene - in turn load game because of OnSceneLoaded() in DPM
            SceneManager.LoadSceneAsync("NewPrototype"); //TODO: Change this string to the be the correct scene in final build
        }

        private void DisableMenuButtons()
        {
            newGameButton.interactable = false;
            continueGameButton.interactable = false;
        }
    }
}
