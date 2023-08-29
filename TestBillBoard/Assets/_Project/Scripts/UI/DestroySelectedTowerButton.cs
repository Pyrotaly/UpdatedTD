using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class DestroySelectedTowerButton : MonoBehaviour
    {
        public void DestroyPlayerTower()
        {
            if (SelectionManager<PlayerTowerUserLogic>.previousSelectedObject != null)
            {
                GameObject.Find("Handlers").GetComponent<BuildingStructureHandler>().DestroyTower(SelectionManager<PlayerTowerUserLogic>.previousSelectedObject.gameObject);
                SelectionManager<PlayerTowerUserLogic>.previousSelectedObject.ManualDestroyTower();
                SelectionManager<PlayerTowerUserLogic>.previousSelectedObject = null;
            }
        }
    }
}
