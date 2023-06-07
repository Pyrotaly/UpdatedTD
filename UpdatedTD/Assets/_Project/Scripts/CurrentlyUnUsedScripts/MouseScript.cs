using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UpdatedTD
{
    public class MouseScript : MonoBehaviour
    {
        public Camera mainCam;
        private Vector3 worldPos;

        public Action OnMouseLeftDown, OnMouseRightDown, OnMouseUp;
 
        void Update()
        {
            worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            //Exact mouse position, used for changing cursor icon when placing buildings
            transform.position = new Vector3(worldPos.x, worldPos.y, 0);    //TODO: There could issue with z value   
        }

        #region InputManager
        public void OnLeftMouseClick(InputAction.CallbackContext context)
        {
            OnMouseLeftDown?.Invoke();
        }

        public void OnRightMouseClick(InputAction.CallbackContext context)
        {
            OnMouseRightDown?.Invoke();
        }
        #endregion
    }
}
