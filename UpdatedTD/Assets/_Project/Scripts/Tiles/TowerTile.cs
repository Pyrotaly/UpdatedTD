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
        //[SerializeField] private GameObject towerAttackRadiusSprite;
        private GameObject attackRadiusIndicatorHolder;
        private Vector3Int TEMPtowerCenter;

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(location, tilemap, ref tileData);
            TEMPtowerCenter = location;
            tileData.sprite = towerSO.TowerInfo.TowerSprite;
        }

        //TODO : Maybe this can be on tower selected, add in sound effects or play a little animation
        public void SpawnAttackRadiusIndicator()
        {
            Debug.Log("Spawn");
            GameObject towerAttackRadiusSprite = GameAssetsHolderManager.Instance.AttackRadiusSprite;
            attackRadiusIndicatorHolder = Instantiate(towerAttackRadiusSprite, TEMPtowerCenter, Quaternion.identity);
        }

        public void DestroyAttackRadiusIndicator()
        {
            Debug.Log("Destroy");

            if (attackRadiusIndicatorHolder != null)
            {
                Destroy(attackRadiusIndicatorHolder);
                attackRadiusIndicatorHolder = null;
            }
        }
    }
}
