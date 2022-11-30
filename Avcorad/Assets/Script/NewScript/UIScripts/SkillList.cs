using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    public GameObject Skillslot;
    public ISkill[] skill;
    // Start is called before the first frame update
    void Start()
    {
        skill = Skillslot.GetComponentsInChildren<ISkill>();
    }

}
