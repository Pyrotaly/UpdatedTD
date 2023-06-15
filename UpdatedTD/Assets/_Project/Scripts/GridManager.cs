using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int width, height;
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private GameObject tileFolder;

        private Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();

        private Vector3 tileRotation = new Vector3(65.049f, 33.669f, 36.305f);

        private void Start()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for (int x = 1; x < width; x++)
            {
                for (int y = 1; y < height; y++)
                {
                    Tile spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile{x}{y}";

                    bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                    spawnedTile.transform.SetParent(tileFolder.transform);

                    tiles[new Vector2(x, y)] = spawnedTile;
                }
            }

            tileFolder.transform.rotation = Quaternion.Euler(tileRotation);
            //tileFolder.transform.rotation = Quaternion.Euler(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z);
        }

        public Tile GetTileAtPosition(Vector2 position)
        {
            if (tiles.TryGetValue(position, out Tile tile))
            {
                return tile;
            }

            return null;
        }
    }
}
