using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class PlayerTowerUserLogic : BaseTowerUserLogic
    {
        public bool Initiazlied = false;
        public PlayerTowerSO.Directions towerDir = PlayerTowerSO.Directions.Down;

        //TODO : Check if it i put in a PlayerTowerSO or tell me if i messed up
        public PlayerTowerSO GetTowerInfo()
        {
            return (PlayerTowerSO)towerInfo; 
        }

        public override void Deselect()
        {
            base.Deselect();
        }

        //TODO : This select function might not need to be overriden as it will probably function the same for all towers, put functionality into the base class
        public override void Select()
        {
            base.Select();

            if (Initiazlied)
            {
                //If clicked on same object
                if (SelectionManager<BaseTowerUserLogic>.SelectedSameObject(this))
                {
                    GameObject.Find("Handlers").GetComponent<MenusHandler>().EnableMoreInfoUI();
                    HelperFunctions.SetDescriptionText("Clicked on me again");

                    var temp = GetTowerInfo();
                    Debug.Log(towerDir);
                }
                //First time selecting or this is new selection
                else
                {
                    GameObject.Find("Handlers").GetComponent<MenusHandler>().EnableMoreInfoUI();
                    HelperFunctions.SetDescriptionText("First clicked");

                    var temp = GetTowerInfo();
                    Debug.Log(towerDir);
                }
            }
        }
    }
}
