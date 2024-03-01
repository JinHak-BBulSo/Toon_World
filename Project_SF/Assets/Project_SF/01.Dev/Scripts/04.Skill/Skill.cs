using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float coolTime;
}
public enum SkillType
{
    NONE = -1,
    DEAL,
    BUFF,
    PASSIVE
}
