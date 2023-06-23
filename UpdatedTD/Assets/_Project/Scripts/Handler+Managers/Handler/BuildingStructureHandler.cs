using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class BuildingStructureHandler : MonoBehaviour
    {
        //TODO : Right now I am super lazy on figuring out how to pass reference that is not static
        // if i do event with the multiple shops, i would need building structure handler to have component reference to all of them which i guess is fine...
        public static GameObject TowerToBePlaced;
        public static GameObject SelectedTile;

        [SerializeField] private GridHandler gridHandler;

        PlayerTowerSO.Directions towerDir = PlayerTowerSO.Directions.Down;
        private GameObject towerCursor;
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
            if (inBuildState) 
            {
                towerCursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                HandleBuilding(); 
            }
        }

        private void HandleBuilding()
        {
            PlayerTowerSO towerSO = TowerToBePlaced.GetComponent<PlayerTowerUserLogic>().GetTowerInfo();

            //Rotate structure
            if (Input.GetMouseButtonDown(1))
            {
                towerDir = PlayerTowerSO.GetNextDir(towerDir);
                Debug.Log(towerDir);
            }

            if (SelectedTile != null && Input.GetMouseButtonDown(0))
            {
                bool canBuild = true;

                List<Vector3Int> tileCoordinatesToCheck =
                    towerSO.CoordinatesTowerTakesUp(new Vector3Int((int)SelectedTile.transform.position.x, (int)SelectedTile.transform.position.y, (int)SelectedTile.transform.position.z), towerDir);

                //Checking if can build in area
                foreach (Vector3Int cooridnate in tileCoordinatesToCheck) 
                {
                    BuildingTiles buildingTile = gridHandler.GetTileAtPosition(cooridnate);

                    if (buildingTile.isBuildable == false) 
                    {
                        //TODO : Play error sign, send message saying cannot build
                        canBuild = false;
                        Debug.Log("Cannot build here");
                        break;
                    }
                }

                if (canBuild)
                {
                    foreach (Vector3Int cooridnate in tileCoordinatesToCheck)
                    {
                        BuildingTiles buildingTile = gridHandler.GetTileAtPosition(cooridnate);
                        buildingTile.SetBuildable(false);
                    }

                    Destroy(towerCursor);

                    Instantiate(TowerToBePlaced,
                        new Vector3((int)SelectedTile.transform.position.x, (int)SelectedTile.transform.position.y + 1, (int)SelectedTile.transform.position.z),
                        Quaternion.identity);

                    TowerToBePlaced = null;
                    towerDir = PlayerTowerSO.Directions.Down;
                    GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
                }
            }
        }

        private void GameManager_OnGameStateChanged(GameManager.GameState state)
        {
            inBuildState = (state == GameManager.GameState.Building);

            if (state == GameManager.GameState.Building)
            {
                inBuildState = true;
                towerCursor = Instantiate(TowerToBePlaced);
            }
            else
            {
                inBuildState = false;
                towerCursor = null;
            }
        }
    }
}
