using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GenericPauseMenu
{
    public class PauseMenuANDGameOver : MonoBehaviour
    {
        public static bool GameIsPaused;
        [SerializeField] private GameObject pauseMenuUI;
        [SerializeField] private GenericMenuFader.SceneTransistionFader sceneFader;

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.started && GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        private void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        // Loads the last checkpoint or save file
        public void Reload()
        {
            Time.timeScale = 1f;
            Scene scene = SceneManager.GetActiveScene();
            sceneFader.FadeToLevel(scene.buildIndex);
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void ExitToDesktop()
        {
            //Ask to save?
            Application.Quit();
        }
    }
}
