using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [CreateAssetMenu(fileName = "New Tower", menuName = "Tower/New Tower")]
    public class PlayerTowerInfoSO : ScriptableObject
    {
        public TowerInfoStruct TowerInfo;

        [Header("Information for Player")]
        public int TowerPrice;
        //TODO : Have area tower takes up
        public string TowerDescription;
    }

    [System.Serializable]
    public struct TowerInfoStruct
    {
        [Header("Base Information")]
        public string TowerName;
        public int ItemID;

        [Header("Combat Information")]
        public int Health;
        public int Damage;
        public float AttackRange;
        public GameObject TEMPProjectile;
    }
}
