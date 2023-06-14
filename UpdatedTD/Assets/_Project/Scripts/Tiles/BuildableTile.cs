using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    [CreateAssetMenu(fileName = "New Custom Tile", menuName = "Tiles/Custom Tile")]
    public class BuildableTile : TileBase
    {
        public Sprite sprite;
        [SerializeField] private bool isBuildable = true;

        public bool IsBuildable
        {
            get { return isBuildable; }
            set { isBuildable = value; }
        }

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(location, tilemap, ref tileData);
            tileData.sprite = sprite;
        }
    }
}
