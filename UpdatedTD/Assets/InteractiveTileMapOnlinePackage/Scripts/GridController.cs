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
        [SerializeField] private Tile hoverTile;

        private Vector3Int previousMousePos = new Vector3Int();

        void Update()
        {
            //Highlights tile mouse is hovering
            Vector3Int mousePos = GetMousePos();
            if (!mousePos.Equals(previousMousePos))
            {
                highlightLayerMap.SetTileFlags(mousePos, TileFlags.None);
                highlightLayerMap.SetTile(previousMousePos, null); // Remove old hoverTile
                highlightLayerMap.SetTile(mousePos, hoverTile);
                previousMousePos = mousePos;
            }

            //Lets player build on buildabletiles
            if (Input.GetMouseButton(0))
            {
                TileBase clickedTerrainTile = terrainLayerMap.GetTile(mousePos);

                if (clickedTerrainTile == null) { return; }

                if (clickedTerrainTile is BuildableTile buildableTile)
                {
                    towerLayerMap.SetTile(mousePos, hoverTile); //TODO : Replace hovertile with whatever tower player selected...and check if selected tower
                    Debug.Log(buildableTile.IsBuildable());
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
