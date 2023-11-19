using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour

{

public GameObject skillItemPrefab; //技能项预制体

public Transform skillItemList; //技能项列表

void Start()

{

    foreach (Skill skill in SkillManager.instance.skills)

    {

        //创建技能项

        GameObject skillItem = Instantiate(skillItemPrefab, skillItemList);

        skillItem.GetComponent<SkillItem>().SetSkill(skill);

    }

}

}