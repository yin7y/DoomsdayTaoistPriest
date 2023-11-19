using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect

{

public float lastActivateTime; //上次激活时间

public virtual void Activate()

{

    lastActivateTime = Time.time;

}

}