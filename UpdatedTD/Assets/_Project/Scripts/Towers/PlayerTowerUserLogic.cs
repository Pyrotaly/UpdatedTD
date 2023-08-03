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
            Destroy(transform.parent.gameObject);
        }

        public override void Select()
        {
            base.Select();

        }
    }
}
