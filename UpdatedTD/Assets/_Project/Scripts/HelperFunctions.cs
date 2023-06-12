using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public static class HelperFunctions
    {
        private static Grid grid;
        public static Grid Gridlayout
        {
            get
            {
                if (grid == null) grid = GameObject.Find("Grid").GetComponent<Grid>();
                return grid;
            }
        }

        public static Vector3 CellToWorld(Vector3Int tilePosition)
        {
            Vector3 worldPosition = Gridlayout.CellToWorld(tilePosition);
            Debug.Log(worldPosition);
            return worldPosition;
        }
    }
}
