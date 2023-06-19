using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerTile : MonoBehaviour, ISelectable
    {
        [SerializeField] private PlayerTowerInfoSO towerInfo;

        public PlayerTowerInfoSO GetTowerInfo()
        {
            return towerInfo;
        }

        public void Select()
        {
            //Play sound effect
            //Turn on radius attack
            //Display description and stuff
        }

        public void Deselect()
        {

        }
    }
}
