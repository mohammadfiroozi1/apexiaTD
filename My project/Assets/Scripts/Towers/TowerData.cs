using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum TowerType
{
    SingleTarget, AoeTarget
}

[CreateAssetMenu(menuName = "Data/Tower Data", fileName = "Tower Data")]
public class TowerData : ScriptableObject
{
    [Header("Type Options")]
    public TowerType type;

    [Header("Damage Options")]
    public int defaulDmg;

    [Header("Attack Options")]
    public float attackCooldown;
    public float attackRadius;
   

}
