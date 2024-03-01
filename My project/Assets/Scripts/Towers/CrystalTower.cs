using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTower : Toweres
{

    Transform targetEnemy;
    private float lastAttackTime = 0;
    public override void Update()
    {
        FindTarget();
        Attack();

    }

    public override void FindTarget()
    {
        base.FindTarget();
        var colliders = Physics.OverlapSphere(transform.position, data.attackRadius, enemyLayer);
        if(colliders.Length > 0)
        {
            targetEnemy = colliders[0].transform;
        }
        else
        {
            targetEnemy = null;
        }
    }

    public override void Attack()
    {
        base.Attack();
        if(targetEnemy != null && Time.time - lastAttackTime > 1 / data.attackCooldown)
        {
            SpawnProjectile();
            lastAttackTime = Time.time;

        }
    }

    void SpawnProjectile()
    {
        var projectile = data.projectile.data.projectilePool.pool.Get();
        projectile.transform.position = projectileSpawnPos.position;


    }

}
