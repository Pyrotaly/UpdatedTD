using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

namespace UpdatedTD
{
    public class UISkillUpgrade : MonoBehaviour
    {
        //TODO : Is there a correct way to like handle missing error things?

        private void Awake()
        {
            transform.Find("SkillButton").GetComponent<Button_UI>().ClickFunc = () => { Debug.Log("Haha"); };
        }
    }
}
