using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [System.Serializable]
    public struct TowerInfoStruct 
    {
        [Header("Base Information")]
        public Sprite TowerSprite;
        public string TowerName;
        public int ItemID;

        [Header("Combat Information")]
        public int Health;
        public int Damage;

        //TODO : Have projectile prefab here to spawn
    }
}
