using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UpdatedTD
{
    [CreateAssetMenu]
    public class TileData : ScriptableObject
    {
        public TileBase[] tiles;

        public bool canBuildOnTop;
    }
}
