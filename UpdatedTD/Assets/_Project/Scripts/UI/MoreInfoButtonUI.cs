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
            //Clicked same button then toggle UI
            if ((Object)SelectionManager<ISelectable>.selectedObject == this)
            {
                ToggleVisibility();
                return;
            }

            SelectionManager<ISelectable>.DeselectObject();
            SelectionManager<ISelectable>.SelectObject(this);
        }

        public void Deselect()
        {
        }
    }
}
