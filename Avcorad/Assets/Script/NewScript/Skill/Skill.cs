using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;

public class Skill : MonoBehaviour, ISkill
{
    public float SkillDamage { get; set; }
    public float needMp { get; set; }
    public float coolTime { get; set; }
    public int needLevel { get; set; }

    protected bool isUse = false;

    public virtual void Init()
    {

    }

    public virtual void useSkill()
    {

    }
}
