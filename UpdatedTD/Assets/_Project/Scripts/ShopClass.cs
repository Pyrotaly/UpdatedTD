using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UpdatedTD
{
    public class ShopClass : MonoBehaviour
    {
        //buttonTemplate is a prefab
        [SerializeField] private Transform buttonTemplate;
        //[SerializeField] private Button buttonTemplateButton;
        [SerializeField] private Transform newButtonParent;
        [SerializeField] private float itemHeight;

        [Header("TEMP TESTING CREATE ITEMS")]
        public PlayerTowerInfoSO Tower1;
        public PlayerTowerInfoSO Tower2;

        private int positionIndex;

        private void Start()
        {
            //Testing Functions
            CreateItemButton(Tower1);
            CreateItemButton(Tower2);

            buttonTemplate.gameObject.SetActive(false);
        }


        private void CreateItemButton(PlayerTowerInfoSO towerSO)
        {
            //Spawn template in menu
            Transform newButtonTransform = Instantiate(buttonTemplate, newButtonParent);
            RectTransform newButtonRectTransform = newButtonTransform.GetComponent<RectTransform>();
            newButtonRectTransform.anchoredPosition = new Vector2(0, -itemHeight * positionIndex);
            positionIndex++;

            newButtonTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText(towerSO.TowerPrice.ToString());
            newButtonTransform.Find("TowerIcon").GetComponent<Image>().sprite = towerSO.TowerInfo.TowerSprite;

            //buttonTemplate.GetComponent<Button>().onClick.AddListener(BuyItem(towerSO));
        }

        private void BuyItem(PlayerTowerInfoSO towerSO)
        {
            CurrencyHandler.Instance.AlterCurrencyValue(-towerSO.TowerPrice);
        }
    }
}
