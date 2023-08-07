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

        public void ManualDestroyTower()
        {
            //TODO : Make some currency back? how would this change if player upgrade the tower?
            Debug.Log("SDFSD");
            Destroy(transform.parent.gameObject);
        }

        protected override void Die()
        {
            Destroy(transform.parent.gameObject);
        }

        public override void Select()
        {
            base.Select();

            if (Initiazlied)
            {
                //If clicked on same object
                if (SelectionManager<PlayerTowerUserLogic>.SelectedSameObject(this))
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

        private void RevertTowerLayer()
        {
            gameObject.layer = LayerMask.NameToLayer("PlayerTowers");

        }
        private void OnMouseEnter()
        {
            if (GameManager.Instance.State == GameManager.GameState.Building)
            {
                Invoke("RevertTowerLayer", 0.5f);
                gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
        }
        #region MouseFunctions
        //TODO : Do enemies need this features as well?


        private void OnMouseDown()
        {
            Debug.Log("jajha");
            Select();
        }
        #endregion
    }
}
