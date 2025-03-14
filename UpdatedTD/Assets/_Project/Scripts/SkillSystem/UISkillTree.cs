using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

namespace UpdatedTD
{
    public class UISkillTree : MonoBehaviour
    {
        //TODO : Make this into node system (i think is the ideal version in sequal)
        private void Awake()
        {
            transform.Find("SkillButton1").GetComponent<Button_UI>().ClickFunc = () => { UpgradeTowerTop(); };
            transform.Find("SkillButton2").GetComponent<Button_UI>().ClickFunc = () => { UpgradeTowerTop(); };
            transform.Find("SkillButton3").GetComponent<Button_UI>().ClickFunc = () => { UpgradeTowerTop(); };
            transform.Find("SkillButton4").GetComponent<Button_UI>().ClickFunc = () => { UpgradeTowerBot(); };
            transform.Find("SkillButton5").GetComponent<Button_UI>().ClickFunc = () => { UpgradeTowerBot(); };
            transform.Find("SkillButton6").GetComponent<Button_UI>().ClickFunc = () => { UpgradeTowerBot(); };
        }

        private void OnEnable()
        {
            if (SelectionManager<PlayerTowerUserLogic>.previousSelectedObject != null)
            {
                var tower = SelectionManager<PlayerTowerUserLogic>.previousSelectedObject.GetComponent<TestTower1Skills>();
                tower.UpgradeTopPath();
            }
        }

        private void UpgradeTowerTop()
        {
            if (SelectionManager<PlayerTowerUserLogic>.previousSelectedObject != null)
            {
                var tower = SelectionManager<PlayerTowerUserLogic>.previousSelectedObject.GetComponent<TestTower1Skills>();
                tower.UpgradeTopPath();
            }
        }

        private void UpgradeTowerBot()
        {
            if (SelectionManager<PlayerTowerUserLogic>.previousSelectedObject != null)
            {
                var tower = SelectionManager<PlayerTowerUserLogic>.previousSelectedObject.GetComponent<TestTower1Skills>();
                tower.UpgradeBotPath();
            }
        }
    }
}
