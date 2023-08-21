using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace UpdatedTD
{
    public class MouseClickDetection : MonoBehaviour
    {
        [SerializeField] private Camera virtualCamera;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = virtualCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.GetComponent<ISelectable>() == null)
                    {
                        SelectionManager<PlayerTowerUserLogic>.SelectedSameObject(null);
                    }
                }
                else
                {
                    SelectionManager<PlayerTowerUserLogic>.SelectedSameObject(null);
                }
            }
        }
    }
}
