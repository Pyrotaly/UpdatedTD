using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class PlayerHealthHandler : MonoBehaviour, IDamageable
    {
        public float Health { get; set; }

        private void OnTriggerEnter(Collider collision)
        {
            //Take damage

            if (Health <= 0)
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.GameOver);
            }
        }
    }
}
