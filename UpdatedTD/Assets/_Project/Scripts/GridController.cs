using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private Tilemap towerLayerMap;
        [SerializeField] private Tilemap highlightLayerMap;
        [SerializeField] private Tilemap terrainLayerMap;
        [SerializeField] private TowerTile TEMPhoverTile;

        private TowerTile previousClickedTower = null;

        private Vector3Int mousePos = new();
        private Vector3Int previousMousePos = new();

        void Update()
        {
            mousePos = GetMousePos();

            HighlightHoveredTile();

            //Handles left clicking on tiles
            if (Input.GetMouseButton(0))
            {
                HandleTowerPlacement();
                HandleSelectingTowers();
            }

            //TODO: Remove tower
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

            if (clickedTerrainTile == null) { return; }

            //Build Tower
            if (clickedTerrainTile is BuildableTile buildableTile && buildableTile == true)
            {
                towerLayerMap.SetTile(mousePos, TEMPhoverTile); //TODO : Replace hovertile with whatever tower player selected (with an action with SO parameter?)

                //if (previousClickedTower != null) { previousClickedTower.Deselected(); }
                //TowerTile placedTowerTile = towerLayerMap.GetTile(mousePos) as TowerTile;
                //placedTowerTile.Selected();

                buildableTile.IsBuildable = false;
            }

            //TODO : Develop system for towers that are greater than 1x1 tiles
        }

        private void HandleSelectingTowers()
        {
            TileBase clickedTowerTile = towerLayerMap.GetTile(mousePos);

            if (clickedTowerTile == null) 
            {
                if (previousClickedTower != null) { previousClickedTower.Deselected(); }
                return; 
            }

            if (clickedTowerTile is not TowerTile towerTile)
            {
                return;
            }

            //TODO : Refactor this, the if statement part just checks if the tiles are differnt not if towers are different, replace with the else statement later
            if (clickedTowerTile != previousClickedTower)
            {
                if (previousClickedTower != null) { previousClickedTower.Deselected(); }

                towerTile.Selected();
                previousClickedTower = towerTile;
            }
            else
            {
                // Compare the world positions of the clicked tiles
                Vector3 clickedTileWorldPos = towerLayerMap.CellToWorld(towerLayerMap.WorldToCell(mousePos));
                Vector3 previousTileWorldPos = previousClickedTower.GetTileCellToWorldPositiion();

                if (clickedTileWorldPos != previousTileWorldPos)
                {
                    // The clicked tile is at a different position, treat it as a new tower click
                    if (previousClickedTower != null) { previousClickedTower.Deselected(); }

                    towerTile.Selected();
                    previousClickedTower = towerTile;
                }
            }
        }

        Vector3Int GetMousePos()
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return grid.WorldToCell(mouseWorldPos);
        }
    }
}
