using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class MoreInfoButtonUI : MonoBehaviour, ISelectable
    {
        [SerializeField] GameObject UI;
        private bool isUIVisible = false;

        private void Start()
        {
            UI.SetActive(false);
        }

        public void ToggleVisibility()
        {
            isUIVisible = !isUIVisible;
            UI.SetActive(isUIVisible);
        }

        public void Select()
        {
            //If clicked on same object
            if (SelectionManager<MoreInfoButtonUI>.SelectedSameObject(this))
            {
                UI.SetActive(!UI.activeSelf);
            }
            //First time selecting or this is new selection
            else
            {
                UI.SetActive(true);
            }
        }

        public void Deselect()
        {
        }
    }
}
