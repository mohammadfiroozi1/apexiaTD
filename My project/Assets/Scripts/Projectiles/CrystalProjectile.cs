using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalProjectile : Projectile
{
    [SerializeField] ProjectileHitEffectPool hitEffectPool;
    ProjectileHitEffect hitEffect;
    public override void Initialize(Transform target, float moveSpeed)
    {
        base.Initialize(target, moveSpeed);
    }


    public override void Update()
    {
        base.Update();
        MoveToTarget(target);
    }
    public override void MoveToTarget(Transform target)
    {
        base.MoveToTarget(target);
        if(target!= null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(0,1f,0), moveSpeed * Time.deltaTime);;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, lastTargetPosition.position, moveSpeed * Time.deltaTime);
            StartCoroutine(DestroyProjectile());

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.gameObject.transform == target)
        {
            var enemy = other.gameObject.GetComponent<Enemies>();
            enemy.takeDmg(GetDamageAmount());
            hitEffect = hitEffectPool.pool.Get();
            hitEffect.transform.position = target.transform.position + new Vector3(0, 1f, 0);
            StartCoroutine(DestroyHitEffect());
            data.projectilePool.OnReleaseObject(this);

        }
    }



    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(0.05f);
        data.projectilePool.OnReleaseObject(this);

    }
    IEnumerator DestroyHitEffect()
    {
        yield return new WaitForSeconds(0.05f);
        hitEffectPool.OnReleaseObject(hitEffect);

    }
}
