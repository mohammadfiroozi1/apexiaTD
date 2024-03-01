using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public  ProjectileData data;
    public Transform target;
    public Transform lastTargetPosition;
    public float moveSpeed;
    public int GetDamageAmount() => data.damage;

    public virtual void Initialize(Transform target, float moveSpeed)
    {
        this.target = target;
        this.moveSpeed = moveSpeed;
        lastTargetPosition = target;
    }


    public virtual void MoveToTarget(Transform target)
    {
        
    }

    public virtual void Update()
    {

    }

}
