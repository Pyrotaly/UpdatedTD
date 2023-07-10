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
            var temp = Instantiate(TestTower, new Vector3(7.1f, 1f, 26.6f), Quaternion.identity);
            temp.GetComponent<BaseTowerUserLogic>().TEMPCallStart();
        }
    }
}
