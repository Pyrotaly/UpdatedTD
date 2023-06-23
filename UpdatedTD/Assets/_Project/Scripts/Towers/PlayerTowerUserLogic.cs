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
        }
    }
}
