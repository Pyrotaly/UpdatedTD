using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class PlayerTowerUserLogic : BaseTowerUserLogic
    {
        //TODO : Check if it is PlayerTowerSO...
        public PlayerTowerSO GetTowerInfo()
        {
            return (PlayerTowerSO)towerInfo; 
        }

        public override void Deselect()
        {
            base.Deselect();
        }

        public override void Select()
        {
            base.Select();

            if (SelectionManager<PlayerTowerUserLogic>.previousSelectedObject == null)
            {
                SelectionManager<PlayerTowerUserLogic>.previousSelectedObject = this;

                //TODO : This is not the most bueatufil thing i guess...
                GameObject.Find("Handlers").GetComponent<MenusHandler>().EnableMoreInfoUI();
                HelperFunctions.SetDescriptionText("HAHAHAHAHHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Debug.Log("Selected " + gameObject.name);
                return;
            }

            if (SelectionManager<BaseTowerUserLogic>.SelectedSameObject(this))
            {
                //If clicked on same tower
                //Do nothing or can disable ui...
                GameObject.Find("Handlers").GetComponent<MenusHandler>().EnableMoreInfoUI();
                HelperFunctions.SetDescriptionText("jjjjjjjjjjjjjjjjjjjjjjjjjjj");
                Debug.Log("Selected again " + gameObject.name);
            }
            else
            {
                //If this new tower player clicked on is not same 
                SelectionManager<PlayerTowerUserLogic>.previousSelectedObject = this;
                Debug.Log("New selection " + gameObject.name);
                GameObject.Find("Handlers").GetComponent<MenusHandler>().EnableMoreInfoUI();
                HelperFunctions.SetDescriptionText("HAHAHAHAHHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                SelectionManager<BaseTowerUserLogic>.CallDeslectOnPreviousObject();
            }
        }
    }
}
