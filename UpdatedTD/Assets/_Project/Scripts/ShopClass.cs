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

        [SerializeField] private GameObject[] purchasableTowers;

        private int positionIndex;

        private void Start()
        {
            InitializeList();
            buttonTemplate.gameObject.SetActive(false);
        }

        private void InitializeList()
        {
            for (int i = 0; i < purchasableTowers.Length; i++)
            {
                CreateItemButton(purchasableTowers[i]);
            }
        }
        //Initialize list with few items.  When player reaches certain thresholds, update list with new items

        private void CreateItemButton(GameObject towerPrefab)
        {
            PlayerTowerInfoSO towerSO = towerPrefab.GetComponent<TowerTile>().GetTowerInfo();

            //Spawn template in scroll menu
            Transform newButtonTransform = Instantiate(buttonTemplate, scrollBarContentHolder);
            RectTransform newButtonRectTransform = newButtonTransform.GetComponent<RectTransform>();
            newButtonRectTransform.anchoredPosition = new Vector2(0, -itemHeight * positionIndex);
            positionIndex++;

            newButtonTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText(towerSO.TowerPrice.ToString());
            newButtonTransform.Find("TowerIcon").GetComponent<Image>().sprite = towerPrefab.GetComponent<SpriteRenderer>().sprite;

            newButtonTransform.GetComponent<Button_UI>().ClickFunc = () => { BuyItem(towerSO); };
        }

        private void BuyItem(PlayerTowerInfoSO towerSO)
        {
            CurrencyHandler.Instance.AlterCurrencyValue(-towerSO.TowerPrice);
            Debug.Log(towerSO.TowerPrice);
        }
    }
}
