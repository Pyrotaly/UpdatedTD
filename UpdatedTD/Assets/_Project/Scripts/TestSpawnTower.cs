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
            var temp = Instantiate(TestTower, TestTowerStartingPoint.position, Quaternion.identity);
            temp.GetComponent<BaseTowerUserLogic>().TEMPCallStart();
        }
    }
}
