using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestSpawnEnemy : MonoBehaviour
    {
        public GameObject TestNemy;

        public void Start()
        {
            var temp = Instantiate(TestNemy);
            temp.GetComponent<BaseTowerUserLogic>().CallStart();
        }
    }
}
