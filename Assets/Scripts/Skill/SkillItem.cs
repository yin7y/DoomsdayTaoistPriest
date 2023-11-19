using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour

{

public Text nameText; //技能名称文本

public Text levelText; //技能等级文本

public Image iconImage; //技能图标

private Skill skill; //技能对象

public void SetSkill(Skill skill)

{

    this.skill = skill;

    nameText.text = skill.name;

    levelText.text = "等级：" + skill.level;

    iconImage.sprite = skill.icon;

}

}
