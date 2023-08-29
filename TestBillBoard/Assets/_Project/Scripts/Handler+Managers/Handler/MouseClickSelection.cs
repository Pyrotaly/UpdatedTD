using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UpdatedTD
{
    public class MouseClickOnTowerDetector : MonoBehaviour
    {
        [SerializeField] private Camera virtualCamera;
        [SerializeField] private LayerMask layer;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = virtualCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Check if the mouse is over a UI element
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }

                if (Physics.Raycast(ray, out hit, layer))
                {
                    if (hit.collider.GetComponent<PlayerTowerUserLogic>() == null)
                    {
                        SelectionManager<PlayerTowerUserLogic>.SelectedSameObject(null);
                        GameObject.Find("Handlers").GetComponent<MenusHandler>().DisableMoreInfoUI();
                    }
                    else
                    {
                        return;
                    }
                }
                //If player clicked absolutely nothing
                else
                {
                    SelectionManager<PlayerTowerUserLogic>.SelectedSameObject(null);
                    GameObject.Find("Handlers").GetComponent<MenusHandler>().DisableMoreInfoUI();
                }
            }
        }
    }
}