using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    [CreateAssetMenu(fileName = "New Custom Tile", menuName = "Tiles/New Tower Tile")]
    public class TowerTile : TileBase
    {
        [SerializeField] private PlayerTowerInfoSO towerSO;

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(location, tilemap, ref tileData);
            tileData.sprite = towerSO.TowerInfo.TowerSprite;
        }
    }
}
