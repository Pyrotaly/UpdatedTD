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

        public static TextMeshProUGUI DescriptionText1
        {
            get
            {
                if (descriptionText1 == null) descriptionText1 = GameObject.Find("MoreInfoOverflowDescription/ Basic Tower Description").GetComponent<TextMeshProUGUI>();
                return descriptionText1;
            }
        }

        public static void SetDescriptionText(string DescriptionText)
        {
            DescriptionText1.SetText(DescriptionText);
        }

    }
}
