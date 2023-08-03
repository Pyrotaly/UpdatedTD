using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestSpawnTower : MonoBehaviour
    {
        public GameObject TestTower;
        public Transform TestTowerStartingPoint;

        public void Start()
        {
            //TODO : Set up rotation due to new art rotation, delete this entire script later...
            var temp = Instantiate(TestTower, TestTowerStartingPoint.position, Quaternion.Euler(transform.rotation.x, 21.647f, transform.rotation.z));
            temp.GetComponent<BaseTowerUserLogic>().CustomInitialize();
        }
    }
}
