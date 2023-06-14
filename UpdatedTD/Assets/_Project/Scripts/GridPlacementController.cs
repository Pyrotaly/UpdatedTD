using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    public class GridPlacementController : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private Tilemap towerLayerMap;
        [SerializeField] private Tilemap highlightLayerMap;
        [SerializeField] private Tilemap terrainLayerMap;
        [SerializeField] private TowerTile TEMPhoverTile;
        [SerializeField] private GameObject TEMPradiusFollower;

        private Vector3Int mousePos = new();
        private Vector3Int previousMousePos = new();

        void Update()
        {
            mousePos = GetMousePos();

            TEMPradiusFollower.transform.localPosition = grid.GetCellCenterLocal(mousePos);
            HighlightHoveredTile();

            //Handles left clicking on tiles
            if (Input.GetMouseButton(0))
            {
                HandleTowerPlacement();
            }

            //Removing towers is on tower script...
            //TODO : Right button click just cancel building 
        }

        private void HighlightHoveredTile()
        {
            if (!mousePos.Equals(previousMousePos))
            {
                highlightLayerMap.SetTileFlags(mousePos, TileFlags.None);
                highlightLayerMap.SetTile(previousMousePos, null);  // Remove old hover tile
                highlightLayerMap.SetTile(mousePos, TEMPhoverTile);
                previousMousePos = mousePos;
            }
        }

        private void HandleTowerPlacement()
        {
            TileBase clickedTerrainTile = terrainLayerMap.GetTile(mousePos);

            if (clickedTerrainTile == null) 
            {
                if (TowerUserLogicHandler.currentSelectedTower != null)
                {
                    TowerUserLogicHandler.currentSelectedTower.DeselectTower();
                    TowerUserLogicHandler.currentSelectedTower = null;
                }

                return; 
            }

            //Build Tower
            if (clickedTerrainTile is BuildableTile buildableTile && buildableTile.IsBuildable == true)
            {
                GameObject temp;
                towerLayerMap.SetTile(mousePos, TEMPhoverTile); //TODO : Replace hovertile with whatever tower player selected (with an action with SO parameter?)
                temp = Instantiate(TEMPradiusFollower, grid.GetCellCenterLocal(mousePos), Quaternion.identity); //Quaternion.Euler(-48.26f, -0.32f, 0f)
                temp.GetComponentInChildren<BaseTowerAttackLogicHandler>().Initialize();

                BuildableTile newBuildableTile = ScriptableObject.CreateInstance<BuildableTile>();
                newBuildableTile.sprite = buildableTile.sprite;
                newBuildableTile.IsBuildable = false;

                terrainLayerMap.SetTile(mousePos, newBuildableTile);
            }

            //TODO : Develop system for towers that are greater than 1x1 tiles
        }

        Vector3Int GetMousePos()
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return grid.WorldToCell(mouseWorldPos);
        }
    }
}
