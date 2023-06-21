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
        public Sprite TowerCursorSprite;
        public int TowerPrice;
        public string TowerDescription;
        public int Height = 1;
        public int Width = 1;

        //TODO : Have area tower takes up
        //TODO : Handle tower direction, just switch height and width values depending on orientation

        public List<Vector3Int> CoordinatesTowerTakesUp(Vector3Int tileCooridnatePlayerClicked)
        {
            List<Vector3Int> coordinatesTowerTakesUp = new List<Vector3Int>();

            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    coordinatesTowerTakesUp.Add(tileCooridnatePlayerClicked + new Vector3Int(x, 0, z));
                }
            }

            return coordinatesTowerTakesUp;
        }
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
