using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    //[ExecuteInEditMode]
    public class GridHandler : MonoBehaviour
    {
        [SerializeField] private int width, height;
        [SerializeField] private BuildingTiles tilePrefab;
        [SerializeField] private GameObject tileFolder;

        public Dictionary<Vector3, GameObject> tiles;

        private void Start()
        {
            tiles = FindGame

            foreach (KeyValuePair<Vector3, GameObject> kvp in TileDictionary.tilesDictionary)
            {
                Vector3 position = kvp.Key;
                GameObject cube = kvp.Value;

                Debug.Log("Key: " + position + ", Value: " + cube.name);
            }
        }

        public BuildingTiles GetTileAtPosition(Vector3 position)
        {
            if (TileDictionary.tilesDictionary.TryGetValue(position, out GameObject tile))
            {
                return tile.GetComponent<BuildingTiles>();
            }

            return null;
        }
    }
}
