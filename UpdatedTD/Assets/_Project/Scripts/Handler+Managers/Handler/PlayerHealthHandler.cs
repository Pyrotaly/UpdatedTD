using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class PlayerHealthHandler : MonoBehaviour, IDamageable
    {
        //TODO : SAVE SYSTEM FOR PLAYER HEALTH
        public float Health { get; set; } = 100;

        public void AlterHealth(float healthAlterAmount)
        {
            Health += healthAlterAmount;

            if (Health <= 0)
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.GameOver);
            }
        }
    }
}
