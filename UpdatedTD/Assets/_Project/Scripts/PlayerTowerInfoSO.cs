using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [CreateAssetMenu(fileName = "New Tower", menuName = "Tower/New Tower")]
    public class PlayerTowerInfoSO : ScriptableObject
    {
        public TowerInfoStruct TowerInfo;

        [Header("Additional Information")]
        public int TowerPrice;
        //TODO : Have area tower takes up
    }
}
