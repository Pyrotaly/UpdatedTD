using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class BuildingStructureHandler : MonoBehaviour
    {
        //TODO : Add mouse feature


        //TODO : Right now I am super lazy on figuring out how to pass reference that is not static
        // if i do event with the multiple shops, i would need building structure handler to have component reference to all of them which i guess is fine...
        public static GameObject TowerToBePlaced;
        public static GameObject HighlightedTile;

        [SerializeField] private GridHandler gridHandler;
        private bool inBuildState;

        private void Awake()
        {
            GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
        }

        private void Update()
        {
            if (inBuildState) { HandleBuilding(); }
        }

        private void HandleBuilding()
        {
            Debug.Log(TowerToBePlaced);

            PlayerTowerInfoSO towerSO = TowerToBePlaced.GetComponent<TowerTile>().GetTowerInfo();
            /* 
             * When player click on a tile, check if all tiles can be built on
             * if can built then spawn prefab where player clicked, make all the tiles notbuildable and TowerToBePlaced = null;
             */
            if (HighlightedTile != null && Input.GetMouseButtonDown(0))
            {
                Debug.Log(new Vector3Int((int)HighlightedTile.transform.position.x, (int)HighlightedTile.transform.position.y, (int)HighlightedTile.transform.position.z));
                List<Vector3Int> tileCoordinatesToCheck =
                    towerSO.CoordinatesTowerTakesUp(new Vector3Int((int)HighlightedTile.transform.position.x, (int)HighlightedTile.transform.position.y, (int)HighlightedTile.transform.position.z));

                GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
            }
        }

        private void GameManager_OnGameStateChanged(GameManager.GameState state)
        {
            inBuildState = (state == GameManager.GameState.Building);
        }
    }
}
