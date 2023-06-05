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
        [SerializeField] private Tilemap _tilemap;

        private void Start()
        {
            _tilemap = GetComponent<Tilemap>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = _tilemap.WorldToCell(mouseWorldPos);
            TileBase tile = _tilemap.GetTile(cellPos);

            Debug.Log("Hey");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
