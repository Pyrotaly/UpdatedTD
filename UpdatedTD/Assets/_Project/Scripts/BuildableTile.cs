using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    [CreateAssetMenu(fileName = "New Custom Tile", menuName = "Tiles/Custom Tile")]
    [System.Serializable]
    public class BuildableTile : TileBase
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private bool isBuildable;

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(location, tilemap, ref tileData);
            tileData.sprite = sprite;

        }
        public bool IsBuildable()
        {
            return isBuildable;
        }
    }
}
