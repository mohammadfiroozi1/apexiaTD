using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTower : Toweres
{

    Transform targetEnemy;
    float attackCooldown;

    private void Start()
    {
        attackCooldown = data.attackCooldown;
    }
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
        if(targetEnemy != null)
        {
            attackCooldown-=Time.deltaTime;
            if (attackCooldown <= 0)
            {
                print("hi");

                SpawnProjectile();
                attackCooldown = data.attackCooldown;
            }

        }
    }

    void SpawnProjectile()
    {
        var projectile = data.projectile.data.projectilePool.pool.Get();
        projectile.transform.position = projectileSpawnPos.position;
        projectile.Initialize(targetEnemy, data.projectile.data.moveSpeed);

    }

}
