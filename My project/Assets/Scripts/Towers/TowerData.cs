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
    [Header("Projectile")]
    public Projectile projectile;

    [Header("Type Options")]
    public TowerType type;

    [Header("Attack Options")]
    public float attackCooldown;
    public float attackRadius;
   

}
