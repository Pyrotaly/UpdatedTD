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
        private GameObject attackRadiusIndicatorHolder;
        private Vector3Int tileGridLocation;
        private Vector3 worldLocation;

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(location, tilemap, ref tileData);
            tileGridLocation = location;
            tileData.sprite = towerSO.TowerInfo.TowerSprite;
        }

        public Vector3 GetTileCellToWorldPositiion()
        {
            return worldLocation = HelperFunctions.CellToWorld(tileGridLocation);
        }

        //TODO : Add in sound effects or play a little animation
        public void Selected()
        {
            Debug.Log(tileGridLocation);
            Debug.Log("Spawn");
            GameObject towerAttackRadiusSprite = GameAssetsHolderManager.Instance.AttackRadiusSprite;

            GetTileCellToWorldPositiion();
            attackRadiusIndicatorHolder = Instantiate(towerAttackRadiusSprite, worldLocation, Quaternion.identity);
        }

        public void Deselected()
        {
            if (attackRadiusIndicatorHolder != null)
            {
                Destroy(attackRadiusIndicatorHolder);
                attackRadiusIndicatorHolder = null;
            }
        }
    }
}
