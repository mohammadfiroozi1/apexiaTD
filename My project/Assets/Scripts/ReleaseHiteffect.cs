using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReleaseHiteffect : MonoBehaviour
{
    [SerializeField] ProjectileHitEffectPool hiteffectPool;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        hiteffectPool.OnReleaseObject(this.GetComponent<ProjectileHitEffect>());
    }

}
