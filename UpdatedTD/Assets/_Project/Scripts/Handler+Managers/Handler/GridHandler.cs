using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    //[ExecuteInEditMode]
    public class GridHandler : MonoBehaviour
    {
        [SerializeField] private int width, height;
        [SerializeField] private BuildingTiles tilePrefab;
        [SerializeField] private GameObject tileFolder;

        public Dictionary<Vector3, BuildingTiles> tiles = new Dictionary<Vector3, BuildingTiles>();

        private void Start()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for (int x = 1; x < width; x++)
            {
                for (int z = 1; z < height; z++)
                {
                    BuildingTiles spawnedTile = Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                    spawnedTile.name = $"Tile{x}{0}{z}";

                    //bool isOffset = (x % 2 == 0 && z % 2 != 0) || (x % 2 != 0 && z % 2 == 0);
                    spawnedTile.transform.SetParent(tileFolder.transform);

                    tiles[new Vector3(x, 0, z)] = spawnedTile;
                }
            }
        }

        public BuildingTiles GetTileAtPosition(Vector3 position)
        {
            if (tiles.TryGetValue(position, out BuildingTiles tile))
            {
                return tile;
            }

            return null;
        }
    }
}
