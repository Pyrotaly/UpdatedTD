using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    public static class HelperFunctions
    {
        private static Grid grid;
        private static Tilemap towerTilemap;

        public static Grid Gridlayout
        {
            get
            {
                if (grid == null) grid = GameObject.Find("Grid").GetComponent<Grid>();
                return grid;
            }
        }

        public static Tilemap TowerTilemap
        {
            get
            {
                if (towerTilemap == null) towerTilemap = GameObject.Find("TowerLayer").GetComponent<Tilemap>();
                return towerTilemap;
            }
        }

        public static Vector3 CellToWorld(Vector3Int tilePosition)
        {
            Vector3 worldPosition = Gridlayout.CellToWorld(tilePosition);
            return worldPosition;
        }

        public static void DestroyTowerOnCell(Vector3Int tilePosition)
        {
            towerTilemap.SetTileFlags(tilePosition, TileFlags.None);
            towerTilemap.SetTile(tilePosition, null);
        }
    }
}
