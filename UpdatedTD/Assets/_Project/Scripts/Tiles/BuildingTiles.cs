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
        public bool isBuildable = true;

        private void Start()
        {
            cubeRenderer = GetComponent<Renderer>();
            originalColor = cubeRenderer.material.color;
        }

        public void SetBuildable(bool boolValue)
        {
            isBuildable = boolValue;
            cubeRenderer.material.color = hoverColor;
        }

        #region MouseFunctions
        private void OnMouseEnter()
        {
            if (isBuildable) { cubeRenderer.material.color = hoverColor; }
            BuildingStructureHandler.HighlightedTile = this.gameObject;
        }

        private void OnMouseExit()
        {
            if (isBuildable) { cubeRenderer.material.color = originalColor; }
            BuildingStructureHandler.HighlightedTile = null;
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
