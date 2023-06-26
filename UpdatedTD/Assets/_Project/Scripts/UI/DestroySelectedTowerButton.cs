using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class DestroySelectedTowerButton : MonoBehaviour
    {
        public void DestroyPlayerTower()
        {
            //TODO : Check if previous selected is correct, also previous selected variable name is misleading here but makes sense in other context, the variable
            //is the tower the player has just selected
            if (SelectionManager<BaseTowerUserLogic>.previousSelectedObject != null)
            {
                Destroy(SelectionManager<BaseTowerUserLogic>.previousSelectedObject);
                SelectionManager<BaseTowerUserLogic>.previousSelectedObject = null;
            }
        }
    }
}
