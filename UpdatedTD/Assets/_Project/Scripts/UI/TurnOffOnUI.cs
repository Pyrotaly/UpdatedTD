using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TurnOffOnUI : MonoBehaviour
    {
        [SerializeField] GameObject UI;
        private bool isUIVisible = false;

        private void Start()
        {
            UI.SetActive(false);
        }

        public void ToggleVisibility()
        {
            isUIVisible = !isUIVisible;
            UI.SetActive(isUIVisible);
        }
    }
}
