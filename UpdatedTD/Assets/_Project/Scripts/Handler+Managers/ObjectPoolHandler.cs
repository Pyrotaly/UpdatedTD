using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

//TODO : Make this an objectpool namespace to reuse
namespace GenericObjectPooling
{
    public class ObjectPoolHandler : MonoBehaviour
    {
        public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

        private GameObject objectPoolEmptyHolder;

        private static GameObject playerProjectiles;
        private static GameObject enemyProjectiles;
        private static GameObject enemies;

        public enum PoolType
        {
            PlayerProjectiles,
            EnemyProjectiles,
            Enemies,
            None
        }
        public static PoolType PoolingType;

        private void Awake()
        {
            SetUpEmpties();
        }

        private void SetUpEmpties()
        {
            objectPoolEmptyHolder = new GameObject("PooledObjects");

            playerProjectiles = new GameObject("PlayerProjectiles");
            playerProjectiles.transform.SetParent(objectPoolEmptyHolder.transform);

            enemyProjectiles = new GameObject("EnemyProjectiles");
            enemyProjectiles.transform.SetParent(objectPoolEmptyHolder.transform);

            enemies = new GameObject("Enemies");
            enemies.transform.SetParent(objectPoolEmptyHolder.transform);
        }

        public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.None)
        {
            PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);

            // If pool doesn't exit, create it
            if (pool == null)
            {
                pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
                ObjectPools.Add(pool);
            }

            //Check if any inactive object in pool
            GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

            //GameObject spawnableObj = null;
            //foreach (GameObject obj in pool.InactiveObjects)
            //{
            //    if (obj != null)
            //    {
            //        spawnableObj = obj;
            //        break;
            //    }
            //}

            //If no inactive objects, create one, else reuse inactive object
            if (spawnableObj == null)
            {
                //Set up parent of empty object
                GameObject parentObject = SetParentObject(poolType);

                spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

                if (parentObject != null)
                {
                    spawnableObj.transform.SetParent(parentObject.transform);
                }
            }
            else
            {
                spawnableObj.transform.position = spawnPosition;
                spawnableObj.transform.rotation = spawnRotation;
                pool.InactiveObjects.Remove(spawnableObj);
                spawnableObj.SetActive(true);
            }

            return spawnableObj;
        }

        public static void ReturnObjectToPool(GameObject obj)
        {
            string goName = obj.name.Substring(0, obj.name.Length - 7); //By removing last 7 characters, we remove the word "(Clone)" from object for string lookup

            PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);

            if (pool == null)
            {
                Debug.LogWarning("Trying to release an object that is not pooled: " + obj.name);
            }
            else
            {
                obj.SetActive(false);
                pool.InactiveObjects.Add(obj);
            }
        }

        private static GameObject SetParentObject(PoolType poolType)
        {
            switch (poolType)
            {
                case PoolType.PlayerProjectiles:
                    return playerProjectiles;
                case PoolType.EnemyProjectiles:
                    return enemyProjectiles;
                case PoolType.Enemies:
                    return enemies;
                case PoolType.None:
                    return null;
                default:
                    return null;
            }
        }
    }

    public class PooledObjectInfo
    {
        public string LookupString;
        public List<GameObject> InactiveObjects = new List<GameObject>();
    }
}
