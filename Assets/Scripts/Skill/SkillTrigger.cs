using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTrigger : MonoBehaviour

{

public Skill skill; //技能对象

public float range; //技能触发范围

public float delay; //技能触发延迟时间

private float lastTriggerTime; //上次触发时间

void OnTriggerEnter(Collider other)

{

    if (other.tag == "Player" && Time.time > lastTriggerTime + delay)

    {

        lastTriggerTime = Time.time;

        //触发技能

        skill.Activate();

    }

}

}
