using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System;

namespace UpdatedTD
{
    public class ShopClass : MonoBehaviour
    {
        [Header("Button Template")]
        [SerializeField] private Transform buttonTemplate;
        [SerializeField] private Transform scrollBarContentHolder;

        [Header("Sellables")]
        [SerializeField] private GameObject[] purchasableTowers;

        private void Start()
        {
            InitializeList();
            buttonTemplate.gameObject.SetActive(false);
        }

        //Initialize list with few items.  When player reaches certain thresholds, update list with new items
        private void InitializeList()
        {
            for (int i = 0; i < purchasableTowers.Length; i++)
            {
                CreateItemButton(purchasableTowers[i]);
            }
        }

        private void CreateItemButton(GameObject towerPrefab)
        {
            PlayerTowerInfoSO towerSO = towerPrefab.GetComponent<TowerTile>().GetTowerInfo();

            //Spawn template in scroll menu
            Transform newButtonTransform = Instantiate(buttonTemplate, scrollBarContentHolder);
            RectTransform newButtonRectTransform = newButtonTransform.GetComponent<RectTransform>();

            newButtonTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText(towerSO.TowerPrice.ToString());
            newButtonTransform.Find("TowerIcon").GetComponent<Image>().sprite = towerPrefab.GetComponent<SpriteRenderer>().sprite;
            newButtonTransform.GetComponent<Button_UI>().ClickFunc = () => { BuyItem(towerPrefab, towerSO.TowerPrice); };

            Transform moreInfoButton = newButtonTransform.Find("InfoIconButton");
            moreInfoButton.GetComponent<Button_UI>().ClickFunc = () => { HandleMoreInfoUI(towerSO.TowerDescription); };
        }

        private void BuyItem(GameObject tower, int price)
        {
            //TODO : ASK HOW LIKE MAKE SURE INSTANCES ARE IN PLACE WHAT IF THERE IS NO BUILDING STRUCTURE HANDLER
            //Make this an event?
            BuildingStructureHandler.TowerToBePlaced = tower;
            CurrencyManager.Instance.AlterCurrencyValue(-price);
            GameManager.Instance.UpdateGameState(GameManager.GameState.Building);
        }

        public void HandleMoreInfoUI(string description)
        {
            HelperFunctions.SetDescriptionText(description);
        }
    }
}
