using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestSpawnEnemy : MonoBehaviour
    {
        public GameObject TestNemy;
        public Transform EnemyStartPoint;

        public void Start()
        {
            var temp = Instantiate(TestNemy, new Vector3(7.1f, 1f, 26.6f), Quaternion.identity);
            temp.GetComponent<BaseTowerUserLogic>().TEMPCallStart();
        }
    }
}
