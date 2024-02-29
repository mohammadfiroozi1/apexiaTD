using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class PoolObject<T> : ScriptableObject where T : Component
{
    public T objectPrefab;
    public ObjectPool<T> pool;

    public void OnEnable()
    {
        pool = new ObjectPool<T>(
            CreateObject, OnGet, OnRelease, OnDestoryObject, false, 100, 100000);
    }

    private void OnDestoryObject(T obj)
    {
        Destroy(obj.gameObject);
    }

    private void OnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    public T CreateObject()
    {
        T obj = Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);
        return obj;
    }


    public virtual void OnReleaseObject(T obj)
    {
        pool.Release(obj);
    }

}
