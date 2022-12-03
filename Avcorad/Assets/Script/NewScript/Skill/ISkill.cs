using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    public float SkillDamage { get; set; }

    public float needMp { get; set; }

    public float coolTime { get; set; }

    public int needLevel { get; set; }

    public void Init();

    public void useSkill();
}
