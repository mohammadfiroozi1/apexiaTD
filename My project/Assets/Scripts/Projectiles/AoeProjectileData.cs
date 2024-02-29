using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Aoe Projectile Data", fileName = "Aoe Projectile Data")]

public class AoeProjectileData : ProjectileData
{
    [Header("Damage Options")]
    public float attackRadius;
}
