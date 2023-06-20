using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class BuildingStructureHandler : MonoBehaviour
    {
        public static GameObject TowerToBePlaced;

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
            //Will exit build mode after building one structure
            if (state == GameManager.GameState.Building)
            {
                Debug.Log(TowerToBePlaced);
                /* 
                 * When player click on a tile, check if all tiles can be built on
                 * if can built then spawn prefab where player clicked, make all the tiles notbuildable and TowerToBePlaced = null;
                 */

                //TODO : Right mouse button rotates building

                GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
            }
        }
    }
}
