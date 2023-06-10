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

        //[SerializeField] private GameObject towerAttackRadiusSprite;

        private Vector3Int mousePos = new Vector3Int();
        private Vector3Int previousMousePos = new Vector3Int();

        void Update()
        {
            mousePos = GetMousePos();

            HighlightHoveredTile();

            //Handles left clicking on tiles
            if (Input.GetMouseButton(0))
            {
                HandleTowerPlacement();
                HandleClickingOnTowers();
            }

            //TODO: Remove tower
        }

        private void HighlightHoveredTile()
        {
            if (!mousePos.Equals(previousMousePos))
            {
                highlightLayerMap.SetTileFlags(mousePos, TileFlags.None);
                highlightLayerMap.SetTile(previousMousePos, null); // Remove old hover tile
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
                buildableTile.IsBuildable = false;
            }
        }

        private void HandleClickingOnTowers()
        {
            TowerTile previousClickedTower = null;
            TileBase clickedTowerTile = towerLayerMap.GetTile(mousePos);

            if (previousClickedTower != null)
            {
                previousClickedTower.DestroyAttackRadiusIndicator();
            }

            if (clickedTowerTile == null) 
            {
                previousClickedTower = null;
                return; 
            }

            if (!(clickedTowerTile is TowerTile towerTile))
            {
                return;
            }

            if (clickedTowerTile != previousClickedTower)
            {
                towerTile.SpawnAttackRadiusIndicator();

                previousClickedTower = towerTile;
            }


            //Show attack radius
            //Instantiate(towerAttackRadiusSprite, mousePos, Quaternion.identity);

            //store previous prefab point and then when clicking anywhere else destroy prefab if there is one to destroy
        }

        Vector3Int GetMousePos()
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return grid.WorldToCell(mouseWorldPos);
        }
    }
}
