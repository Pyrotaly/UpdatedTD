using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class GameAssetsHolderManager : MonoBehaviour
    {
        private static GameAssetsHolderManager instance;

        public static GameAssetsHolderManager Instance
        {
            get { 
                if (instance == null)
                {
                    instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssetsHolderManager>();
                }
                return instance; 
            }
        }

        //[Header("Towers")]
        #region Towers

        #endregion
    }
}
