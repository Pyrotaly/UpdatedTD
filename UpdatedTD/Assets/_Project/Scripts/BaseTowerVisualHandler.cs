using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [RequireComponent(typeof(PlayerTowerUserLogic))]
    public class BaseTowerVisualHandler : MonoBehaviour
    {
        public PlayerTowerSO.Directions towerDir;

        public void CannotBuildTower()
        {
            var sprite = GetComponent<SpriteRenderer>().color;
            sprite = new Color(255f, 0, 0);
        }

        public void ClearCannotBuildTower()
        {
            var sprite = GetComponent<SpriteRenderer>().color;
            sprite = new Color(255f, 255f, 255f);
        }

        //TODO : ADD IN SPRITES
        public void DirectionChangeVisual(PlayerTowerSO.Directions newTowerDir)
        {
            switch (newTowerDir)
            {
                case PlayerTowerSO.Directions.Down:
                    Debug.Log("ChangeSprite1");
                    break;
                case PlayerTowerSO.Directions.Left:
                    Debug.Log("ChangeSprite2");
                    break;
                case PlayerTowerSO.Directions.Up:
                    Debug.Log("ChangeSprite3");
                    break;
                case PlayerTowerSO.Directions.Right:
                    Debug.Log("ChangeSprite4");
                    break;
            }
        }
    }
}