using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class SetGameObjectsFalse : MonoBehaviour
    {
        public GameObject[] ThingsToDisable;

        private void Start()
        {
            Invoke("Disable", 1f);
        }

        private void Disable()
        {
            foreach (GameObject i in ThingsToDisable) { i.SetActive(false); }
        }
    }
}
