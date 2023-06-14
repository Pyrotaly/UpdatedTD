using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TowerUserLogicHandler : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public static TowerUserLogicHandler currentSelectedTower;
        private bool isSelected = false;

        //TODO : Mouse hover functions are located here:
        //perform destroyself function, make function subscribe to right mouse button action
        //spawn description here as well

        private void Update()
        {
            Debug.Log(currentSelectedTower);
        }

        private void OnMouseOver()
        {
            //Left click
            if (Input.GetMouseButton(0))
            {
                //Spawn Description
                if (currentSelectedTower == this)
                {
                    return;
                }

                // Deselect the previously selected tower
                if (currentSelectedTower != null)
                {
                    currentSelectedTower.DeselectTower();
                }

                SelectTower();
            }
        }

        private void SelectTower()
        {
            isSelected = true;
            spriteRenderer.enabled = true;
            currentSelectedTower = this;
            // TODO: Perform any other actions when tower is selected
        }

        public void DeselectTower()
        {
            isSelected = false;
            spriteRenderer.enabled = false;
            // TODO: Perform any other actions when tower is deselected
        }

        public void DestroyThisTower()
        {
            
        }
    }
}
