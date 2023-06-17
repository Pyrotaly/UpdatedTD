using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

namespace UpdatedTD
{
    public static class HelperFunctions
    {
        private static TextMeshProUGUI text;

        public static TextMeshProUGUI Text
        {
            get
            {
                if (text == null) text = GameObject.Find("Description").GetComponent<TextMeshProUGUI>();
                return text;
            }
        }

        public static void SetDescriptionText(string DescriptionText)
        {
            Debug.Log("haha");
            Text.SetText(DescriptionText);
        }
    }
}
