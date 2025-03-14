using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class GameAssetsHolderManager : MonoBehaviour
    {

        public static GameAssetsHolderManager Instance;

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

        [Header("Towers")]
        public GameObject TowerAttackHandler;

        [Header("UI")]
        public GameObject TestTowerSkillTreeUI;
    }
}
