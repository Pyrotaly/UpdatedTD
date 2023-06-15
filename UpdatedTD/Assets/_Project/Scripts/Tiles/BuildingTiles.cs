using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class BuildingTiles : MonoBehaviour
    {
        [Header("Material Management")]
        private Renderer cubeRenderer;
        private Color originalColor;
        [SerializeField] private Color hoverColor;
        [SerializeField] private Color clickColor;

        [Header("Logic Management")]
        private bool isBuildable = true;

        private void Start()
        {
            cubeRenderer = GetComponent<Renderer>();
            originalColor = cubeRenderer.material.color;
        }

        public void SetBuildable(bool boolValue)
        {
            isBuildable = boolValue;
        }

        #region MouseFunctions
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
        #endregion
    }
}
