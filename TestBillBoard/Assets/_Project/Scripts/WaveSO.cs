using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
    public class WaveSO : ScriptableObject
    {
        public GameObject[,] EnemyArray;
        public float[] timeInWave;
    }
}
