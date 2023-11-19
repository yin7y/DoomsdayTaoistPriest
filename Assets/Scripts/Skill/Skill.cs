using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill

{

public string name; //技能名称

public string type; //技能类型

public int consume; //技能消耗

public float cooldown; //技能冷却时间

public int level; //技能等级

public Sprite icon; //技能图标

public SkillEffect effect; //技能效果

public void Activate()

{

    if (Time.time > effect.lastActivateTime + cooldown)

    {

        effect.Activate();

    }

}

}
