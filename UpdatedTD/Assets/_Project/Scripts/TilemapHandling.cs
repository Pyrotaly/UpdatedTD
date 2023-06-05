using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace UpdatedTD
{

    public class TilemapHandling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler    
    {
        private Grid grid;

        [SerializeField] private Tilemap tilemap;
        //[SerializeField] private Tilemap hightlightTilemap;

        [SerializeField] private Tile hoverTile = null;

        private Vector3Int previousMousePos = new Vector3Int();
        private void Start()
        {
            grid = gameObject.GetComponent<Grid>();
        }

        private void Update()
        {
            Vector3Int mousePos = GetMousePos();
            if (!mousePos.Equals(previousMousePos))
            {
                tilemap.SetTile(previousMousePos, null); // Remove old hoverTile
                tilemap.SetTile(mousePos, hoverTile);
                previousMousePos = mousePos;
            }

            Debug.Log(mousePos);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //Vector3Int mousePos = GetMousePos();
            //if (!mousePos.Equals(previousMousePos))
            //{
            //    hightlightTilemap.SetTile(previousMousePos, null); // Remove old hoverTile
            //    hightlightTilemap.SetTile(mousePos, hoverTile);
            //    previousMousePos = mousePos;
            //}

            //Debug.Log("Hey");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        Vector3Int GetMousePos()
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return grid.WorldToCell(mouseWorldPos);
        }
    }
}
