using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public static class SelectionManager<T> where T : MonoBehaviour, ISelectable
    {
        public static T previousSelectedObject;

        public static bool SelectedSameObject(T selectable)
        {
            //If player clicked on same object
            if (previousSelectedObject != null && previousSelectedObject == selectable)
            {
                return true;
            }

            //First click or clicked on different object
            CallDeslectOnPreviousObject();
            previousSelectedObject = selectable;
            return false;
        }

        public static void CallDeslectOnPreviousObject()
        {
            if (previousSelectedObject != null) { previousSelectedObject.Deselect(); }
        }
    }
}
