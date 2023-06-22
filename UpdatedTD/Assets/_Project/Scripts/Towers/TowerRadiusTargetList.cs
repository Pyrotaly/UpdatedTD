using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerRadiusTargetList : MonoBehaviour
    {
        public List<GameObject> targetList = new List<GameObject>();

        private LayerMask targetLayer;

        public void SetUp(LayerMask layerSetup)
        {
            targetLayer = layerSetup;
        }

        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log(targetLayer);
            Debug.Log(collision.gameObject.layer);
            if (collision.gameObject.layer == targetLayer)
            {
                targetList.Add(collision.gameObject);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            //TODO : Do i need to compare on exit?
            if (collision.gameObject.layer == targetLayer)
            {
                targetList.Remove(collision.gameObject);
            }
        }
    }
}
