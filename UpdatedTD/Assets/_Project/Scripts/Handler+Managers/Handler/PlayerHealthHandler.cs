using GenericSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class PlayerHealthHandler : MonoBehaviour, IDamageable, IDataPersistence
    {
        //TODO : SAVE SYSTEM FOR PLAYER HEALTH
        public int Health = 100;

        [SerializeField] private TMPro.TextMeshProUGUI text;

        private void Start()
        {
            text.text = Health.ToString();
        }

        public void AlterCurrentHitPoints(int healthAlterAmount)
        {
            Health += healthAlterAmount;
            text.text = Health.ToString();

            if (Health <= 0)
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.GameOver);
            }
        }

        public void LoadData(GameData data)
        {
            Health = data.playerHealth;
        }

        public void SaveData(ref GameData data)
        {
            data.playerHealth = Health;
        }
    }
}
