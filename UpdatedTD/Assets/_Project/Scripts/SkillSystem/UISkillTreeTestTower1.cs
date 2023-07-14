using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

namespace UpdatedTD
{
    public class UISkillTreeTestTower1 : MonoBehaviour
    {
        //TODO : Is there a correct way to like handle missing error things?

        private void Awake()
        {
            transform.Find("SkillButton1").GetComponent<Button_UI>().ClickFunc = () => { Debug.Log("Haha"); };
            transform.Find("SkillButton2").GetComponent<Button_UI>().ClickFunc = () => { Debug.Log("Haha"); };
            transform.Find("SkillButton3").GetComponent<Button_UI>().ClickFunc = () => { Debug.Log("Haha"); };
            transform.Find("SkillButton4").GetComponent<Button_UI>().ClickFunc = () => { Debug.Log("Haha"); };
        }
    }
}
