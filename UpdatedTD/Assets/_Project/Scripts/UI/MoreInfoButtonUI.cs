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
            if (SelectionManager<MoreInfoButtonUI>.previousSelectedObject == null)
            {
                UI.SetActive(true);
            }

            if (SelectionManager<MoreInfoButtonUI>.SelectedSameObject(this))
            {
                if (UI.activeSelf)
                { 
                    UI.SetActive(false);
                    return;
                }

                UI.SetActive(true);
            }
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
