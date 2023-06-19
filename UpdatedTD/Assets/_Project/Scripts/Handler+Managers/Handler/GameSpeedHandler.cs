using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class GameSpeedHandler : MonoBehaviour
    {
        private enum GameSpeed
        {
            Pause,
            Normal,
            Fast,
            Extreme
        }

        private GameSpeed currentGameSpeed;

        private void Start()
        {
            currentGameSpeed = GameSpeed.Normal;
            Time.timeScale = 1f;
        }

        public void PauseGame()
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Pause);
            Debug.Log("PPause");
            currentGameSpeed = GameSpeed.Pause;
            Time.timeScale = 0f;
        }

        public void ChangeGameSpeed()
        {
            //If clicked while game is paused, set time to 1 and then...
            switch (currentGameSpeed)
            {
                case GameSpeed.Pause:
                    Debug.Log("Normal");
                    Time.timeScale = 1f;
                    currentGameSpeed = GameSpeed.Normal;
                    break;
                case GameSpeed.Normal:
                    Debug.Log("Fast");
                    Time.timeScale = 1.5f;
                    currentGameSpeed = GameSpeed.Fast;
                    break;
                case GameSpeed.Fast:
                    Debug.Log("Extreme");
                    Time.timeScale = 2f;
                    currentGameSpeed = GameSpeed.Extreme;
                    break;
                case GameSpeed.Extreme:
                    Debug.Log("Normal");
                    Time.timeScale = 1f;
                    currentGameSpeed = GameSpeed.Normal;
                    break;
            }

            //TODO : Change UI art to reflect game speed
        }
    }
}