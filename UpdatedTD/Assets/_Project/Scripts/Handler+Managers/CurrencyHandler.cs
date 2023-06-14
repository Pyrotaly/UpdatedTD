using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UpdatedTD
{
    public class CurrencyHandler : MonoBehaviour
    {
        public static CurrencyHandler Instance;
        public static int currency { get; private set; }

        [SerializeField] private TMP_Text text;
        [SerializeField] private int startingCurrency;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            text.text = startingCurrency.ToString();
        }

        public void AlterCurrencyValue(int alterCurrencyAmount)
        {
            currency += alterCurrencyAmount;
            text.text = currency.ToString();
        }
    }
}
