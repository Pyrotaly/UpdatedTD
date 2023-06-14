using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO : Make camera only move when player presses a cetain button, this will allow player to press UI in corner without moving camera

namespace UpdatedTD
{
    public class CameraMovementHandler : MonoBehaviour
    {
        [SerializeField] private float edgeSize = 10f;
        [SerializeField] private float cameraMoveSpeed = 10f;
        [SerializeField] private float zoomChangeSpeed = 10f;
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

        [SerializeField] private float targetOrthographicSize;
        [SerializeField] private float orthographicSizeMin;
        [SerializeField] private float orthographicSizeMax;

        private void Update()
        {
            HandleEdgeScrolling();
            HandleZoom();
        }

        private void HandleEdgeScrolling()
        {
            Vector3 inputDir = new Vector3(0, 0, 0);

            //Move right
            if (Input.mousePosition.x > Screen.width - edgeSize)
            {
                inputDir.x = 1f;
            }
            //Move left
            if (Input.mousePosition.x < edgeSize)
            {
                inputDir.x = -1f;
            }
            //Move up
            if (Input.mousePosition.y > Screen.height - edgeSize)
            {
                inputDir.y = 1f;
            }
            //Move down
            if (Input.mousePosition.y < edgeSize)
            {
                inputDir.y = -1f;
            }


            Vector3 moveDir = transform.up * inputDir.y + transform.right * inputDir.x;

            transform.position += moveDir * cameraMoveSpeed * Time.deltaTime;
        }

        private void HandleZoom()
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                targetOrthographicSize -= 0.4f;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                targetOrthographicSize += 0.4f;
            }

            targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, orthographicSizeMin, orthographicSizeMax);
            cinemachineVirtualCamera.m_Lens.OrthographicSize =
                Mathf.Lerp(cinemachineVirtualCamera.m_Lens.OrthographicSize, targetOrthographicSize, Time.deltaTime * zoomChangeSpeed);
        }
    }
}
