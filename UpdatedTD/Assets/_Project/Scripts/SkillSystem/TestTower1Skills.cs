using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class TestTower1Skills : MonoBehaviour
    {
        public enum SkillType
        {
            Upgrade1
        }

        private List<SkillType> unlockedSkillTypeList;

        public TestTower1Skills()
        {
            unlockedSkillTypeList = new List<SkillType>();
        }

        public void UnlockSkill(SkillType skillType)
        {
            unlockedSkillTypeList.Add(skillType);
        }

        public bool IsSkillUnlocked(SkillType skillType)
        {
            return unlockedSkillTypeList.Contains(skillType);
        }
    }
}
