using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public static class SelectionManager<T> where T : ISelectable
    {
        public static T selectedObject;

        public static void SelectObject(T selectable)
        {
            if (selectedObject != null)
            {
                selectedObject.Deselect();
            }

            selectedObject = selectable;
            selectedObject.Select();
        }

        public static void DeselectObject()
        {
            if (selectedObject != null) { selectedObject.Deselect(); }
        }
    }
}
