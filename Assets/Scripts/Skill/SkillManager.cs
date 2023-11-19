using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour

{

public List<Skill> skills; //技能列表

public static SkillManager instance; //单例对象

void Awake()

{

    instance = this;

}

public Skill GetSkillByName(string name)

{

    foreach (Skill skill in skills)

    {

        if (skill.name == name)

        {

            return skill;

        }

    }

    return null;

}

}
