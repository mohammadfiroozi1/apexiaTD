using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Projectile Data", fileName = "Projectile Data")]

public class ProjectileData : ScriptableObject
{
    [Header("Damage Options")]
    public int damage;

    [Header("Move Options")]
    public float moveSpeed;

    [Header("Projectile Pool")]
    public ProjectilePool projectilePool;

}
