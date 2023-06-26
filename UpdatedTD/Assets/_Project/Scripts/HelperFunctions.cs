using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

namespace UpdatedTD
{
    public static class HelperFunctions
    {
        private static TextMeshProUGUI descriptionText1;
        private static GameObject moreInfoUI;

        public static TextMeshProUGUI DescriptionText1
        {
            get
            {
                if (descriptionText1 == null) descriptionText1 = GameObject.Find("Description").GetComponent<TextMeshProUGUI>();
                return descriptionText1;
            }
        }

        public static GameObject MoreInfoUI
        {
            get
            {
                if (moreInfoUI == null) moreInfoUI = GameObject.Find("MoreInfoUI");
                return moreInfoUI;
            }
        }

        public static void SetDescriptionText(string DescriptionText)
        {
            DescriptionText1.SetText(DescriptionText);
        }

        public static void EnableMoreInfoUI() { MoreInfoUI.SetActive(true); }
        public static void DisableMoreInfoUI() { MoreInfoUI.SetActive(false); }

    }
}
