using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class WIPLevelManager : MonoBehaviour
    {
        public Transform startpoint { get; private set; }

        [SerializeField] private Transform[] path;
        public Transform[] GetPath { get { return path;  } }

        public static WIPLevelManager Instance;

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
    }
}
