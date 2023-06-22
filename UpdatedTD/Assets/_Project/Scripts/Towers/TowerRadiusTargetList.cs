using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerRadiusTargetList : MonoBehaviour
    {
        public List<GameObject> targetList = new List<GameObject>();

        public string TargetTag;

        public void SetUp(string tagSetup)
        {
            TargetTag = tagSetup;
            Debug.Log(TargetTag);
        }

        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log(TargetTag);
            if (collision.gameObject.tag == TargetTag)
            {
                targetList.Add(collision.gameObject);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            //TODO : Do i need to compare on exit?
            if (collision.gameObject.tag == TargetTag)
            {
                targetList.Remove(collision.gameObject);
            }
        }
    }
}
