using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        private List<Vector3Int> previousTileCooridnatesToCheck = new List<Vector3Int>();

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
                towerCursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(transform.position.x + 1.08937f + 0.3f, transform.position.y + 0.16535f - 0.5f, transform.position.z + 3.36638f);
                // towerCursor.transform.position = new Vector3(transform.position.x - 1.08937f, transform.position.y - 0.16535f, transform.position.z - 3.36638f);
                towerCursor.layer = LayerMask.NameToLayer("Ignore Raycast");
                HandleBuilding();
            }
        }

        //TODO : not the best but it works...
        private void HandleBuildingVisual(PlayerTowerSO towerSO)
        {
            if (SelectedTile != null)
            {
                List<Vector3Int> currentTileCoordinatesToCheck =
                    towerSO.CoordinatesTowerTakesUp(new Vector3Int((int)SelectedTile.transform.position.x, (int)SelectedTile.transform.position.y, (int)SelectedTile.transform.position.z), towerDir);

                foreach (Vector3Int cooridnate in currentTileCoordinatesToCheck)
                {
                    BuildingTilesZ1 buildingTile = gridHandler.GetTileAtPosition(cooridnate);

                    //TODO : If it is null, make the tower rd to indicate cannot build there
                    if (buildingTile != null)
                    {
                        buildingTile.ChangeColorBool(true);
                    }
                }

                if (!currentTileCoordinatesToCheck.SequenceEqual(previousTileCooridnatesToCheck))
                {
                    foreach (Vector3Int cooridnate in previousTileCooridnatesToCheck)
                    {
                        BuildingTilesZ1 buildingTile = gridHandler.GetTileAtPosition(cooridnate);

                        if (buildingTile != null)
                        {
                            buildingTile.ChangeColorBool(false);
                        }
                    }

                    previousTileCooridnatesToCheck = currentTileCoordinatesToCheck.ToList();
                }
            }
        }

        private void HandleBuilding()
        {
            PlayerTowerSO towerSO = TowerToBePlaced.GetComponentInChildren<PlayerTowerUserLogic>().GetTowerInfo();

            HandleBuildingVisual(towerSO);

            //Rotate structure
            if (Input.GetMouseButtonDown(1))
            {
                towerDir = PlayerTowerSO.GetNextDir(towerDir);

                //TODO : This is bizzare here...
                TowerToBePlaced.GetComponentInChildren<BaseTowerVisualHandler>().DirectionChangeVisual(towerDir);
            }

            if (SelectedTile != null && Input.GetMouseButtonDown(0))
            {
                bool canBuild = true;

                List<Vector3Int> tileCoordinatesToCheck =
                    towerSO.CoordinatesTowerTakesUp(new Vector3Int((int)SelectedTile.transform.position.x, (int)SelectedTile.transform.position.y, (int)SelectedTile.transform.position.z), towerDir);

                //Checking if can build in area
                foreach (Vector3Int cooridnate in tileCoordinatesToCheck) 
                {
                    BuildingTilesZ1 buildingTile = gridHandler.GetTileAtPosition(cooridnate);

                    if (buildingTile == null) 
                    { 
                        Debug.Log("Cannot build here"); 
                        return; 
                    }

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
                        BuildingTilesZ1 buildingTile = gridHandler.GetTileAtPosition(cooridnate);
                        buildingTile.SetBuildable(false);
                    }

                    Destroy(towerCursor);

                    var tower = Instantiate(TowerToBePlaced,
                        new Vector3((int)SelectedTile.transform.position.x, (int)SelectedTile.transform.position.y + 1, (int)SelectedTile.transform.position.z),
                        Quaternion.identity);

                    tower.GetComponentInChildren<PlayerTowerUserLogic>().Initiazlied = true;
                    tower.GetComponentInChildren<PlayerTowerUserLogic>().towerDir = towerDir;
                    tower.GetComponentInChildren<PlayerTowerUserLogic>().CoordinatesTowerTakesUp = tileCoordinatesToCheck;

                    TowerToBePlaced = null;
                    towerDir = PlayerTowerSO.Directions.Down;
                    GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
                }
            }
        }

        public void DestroyTower(GameObject towerToBeDestroyed)
        {
            PlayerTowerSO towerSO = towerToBeDestroyed.GetComponent<PlayerTowerUserLogic>().GetTowerInfo();

            towerDir = towerToBeDestroyed.GetComponent<PlayerTowerUserLogic>().towerDir;
            Debug.Log(towerDir);

            //List<Vector3Int> tileCoordinatesToCheck =
            //        towerSO.CoordinatesTowerTakesUp(new Vector3Int((int)towerToBeDestroyed.transform.position.x, 
            //        (int)towerToBeDestroyed.transform.position.y - 1, (int)towerToBeDestroyed.transform.position.z), towerDir);

            List<Vector3Int> tileCoordinatesToCheck = towerToBeDestroyed.GetComponent<PlayerTowerUserLogic>().CoordinatesTowerTakesUp;

            foreach (Vector3Int cooridnate in tileCoordinatesToCheck)
            {
                BuildingTilesZ1 buildingTile = gridHandler.GetTileAtPosition(cooridnate);

                if (buildingTile == null)
                {
                    Debug.Log(cooridnate + " tile is missing");
                }
                else 
                {
                    buildingTile.SetBuildable(true);
                }

            }

            towerDir = PlayerTowerSO.Directions.Down;
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
