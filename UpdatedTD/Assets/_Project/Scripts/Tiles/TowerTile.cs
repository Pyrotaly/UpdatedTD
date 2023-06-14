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
        private GameObject tileAttackHandler;
        private Vector3Int tileGridLocation;

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(location, tilemap, ref tileData);
            tileGridLocation = location;
            tileData.sprite = towerSO.TowerInfo.TowerSprite;
        }

        public Vector3 GetTileCellToWorldPositiion()
        {
            return HelperFunctions.CellToWorld(tileGridLocation);
        }

        public void Selected()
        {
            //TODO : Add in sound effects or play a little animation
            //tileAttackHandler.EnableAttackRadius();
            if (tileAttackHandler == null)
            {
                tileAttackHandler = towerSO.TowerInfo.TowerAttackHandler;
                tileAttackHandler = Instantiate(tileAttackHandler, GetTileCellToWorldPositiion(), Quaternion.identity);
                tileAttackHandler.transform.rotation = Quaternion.Euler(-48.26f, -0.32f, 0f);
                tileAttackHandler.GetComponent<TowerLogicHandler>().Initialize(towerSO);
            }
        }

        public void Deselected()
        {
            //towerSO.TowerInfo.TowerAttackHandler.DisableAttackRadius();
        }
    }
}
