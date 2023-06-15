using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class Tile : MonoBehaviour
    {
        private Renderer cubeRenderer;
        private Color originalColor;
        [SerializeField] private Color hoverColor;
        [SerializeField] private Color clickColor;

        private void Start()
        {
            cubeRenderer = GetComponent<Renderer>();
            originalColor = cubeRenderer.material.color;
        }

        private void OnMouseEnter()
        {
            cubeRenderer.material.color = hoverColor;
        }

        private void OnMouseExit()
        {
            cubeRenderer.material.color = originalColor;
        }

        private void OnMouseDown()
        {
            cubeRenderer.material.color = clickColor;
        }

        private void OnMouseUp()
        {
            cubeRenderer.material.color = hoverColor;
        }
    }
}
