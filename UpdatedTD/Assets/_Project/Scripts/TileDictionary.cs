using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TileDictionary : MonoBehaviour
    {
        [SerializeField] private GameObject tilesFolder;
        [SerializeField] private Transform[] cubes;
        public Dictionary<Vector3, GameObject> tilesDictionary;

        private void Start()
        {
            cubes = tilesFolder.GetComponentsInChildren<Transform>();

            // Create the dictionary
            tilesDictionary = new Dictionary<Vector3, GameObject>();

            // HashSet to store unique positions
            HashSet<Vector3> uniquePositions = new HashSet<Vector3>();

            // Process the child GameObjects
            foreach (Transform cubeTransform in cubes)
            {
                // Skip the parent object itself
                if (cubeTransform.gameObject == tilesFolder)
                    continue;

                // Get the position of the child GameObject
                Vector3 position = cubeTransform.position;

                // Check if the position is already in the HashSet
                if (uniquePositions.Contains(position))
                {
                    // The position is already occupied by another GameObject
                    //Debug.Log("Duplicate position found: " + position);
                }
                else
                {
                    // Add the position to the HashSet
                    uniquePositions.Add(position);

                    // Add the position and GameObject to the dictionary
                    tilesDictionary.Add(position, cubeTransform.gameObject);
                }
            }
        }
    }
}
