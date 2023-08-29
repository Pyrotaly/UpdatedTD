using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerRadiusTargetList : MonoBehaviour
    {
        public List<GameObject> targetList = new List<GameObject>();
        public event Action<List<GameObject>> ListUpdated;

        public string TargetTag;

        public void SetUp(string tagSetup)
        {
            TargetTag = tagSetup;
        }

        public void UpdateList(List<GameObject> newList)
        {
            targetList = newList;
            ListUpdated?.Invoke(targetList);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == TargetTag)
            {
                targetList.Add(collision.gameObject);
                UpdateList(targetList);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            //TODO : Do i need to compare on exit?
            if (collision.gameObject.tag == TargetTag)
            {
                targetList.Remove(collision.gameObject);
                UpdateList(targetList);
            }
        }

        //Right now, 
        private void ClearEmpties()
        {

        }
    }
}
