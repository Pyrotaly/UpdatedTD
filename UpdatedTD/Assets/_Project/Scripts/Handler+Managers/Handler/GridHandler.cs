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
        [SerializeField] private BuildingTilesZ1 tilePrefab;
        [SerializeField] private GameObject tileFolder;
        [SerializeField] private TileDictionary cubeDictionary;

        public BuildingTilesZ1 GetTileAtPosition(Vector3 position)
        {
            if (cubeDictionary.tilesDictionary.TryGetValue(position, out GameObject tile))
            {
                return tile.GetComponent<BuildingTilesZ1>();
            }

            return null;
        }
        
    }
}
