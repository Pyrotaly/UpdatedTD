using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CodeMonkey.Utils;

namespace UpdatedTD
{
    public class ShopClass : MonoBehaviour
    {
        //Get button template in scene
        [SerializeField] private Transform buttonTemplate;
        [SerializeField] private Transform scrollBarContentHolder;
        [SerializeField] private float itemHeight;

        [Header("TEMP TESTING CREATE ITEMS")]
        public PlayerTowerInfoSO Tower1;
        public PlayerTowerInfoSO Tower2;

        private int positionIndex;

        private void Start()
        {
            //TEMP TESTING FUNCTIONS
            CreateItemButton(Tower1);
            CreateItemButton(Tower2);

            buttonTemplate.gameObject.SetActive(false);
        }


        private void CreateItemButton(PlayerTowerInfoSO towerSO)
        {
            //Spawn template in scroll menu
            Transform newButtonTransform = Instantiate(buttonTemplate, scrollBarContentHolder);
            RectTransform newButtonRectTransform = newButtonTransform.GetComponent<RectTransform>();
            newButtonRectTransform.anchoredPosition = new Vector2(0, -itemHeight * positionIndex);
            positionIndex++;

            newButtonTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText(towerSO.TowerPrice.ToString());
            newButtonTransform.Find("TowerIcon").GetComponent<Image>().sprite = towerSO.TowerInfo.TowerSprite;

            newButtonTransform.GetComponent<Button_UI>().ClickFunc = () => { BuyItem(towerSO); };
        }

        private void BuyItem(PlayerTowerInfoSO towerSO)
        {
            CurrencyHandler.Instance.AlterCurrencyValue(-towerSO.TowerPrice);
            Debug.Log(towerSO.TowerPrice);
        }
    }
}
