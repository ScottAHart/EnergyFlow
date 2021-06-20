using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectPooler<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField]
    private int poolSize = 10;

    [SerializeField]
    private List<T> activePool = new List<T>();
    [SerializeField]
    private List<T> inactivePool = new List<T>();

    [SerializeField]
    private T objectPrefab;

    [SerializeField]
    bool expandIfNeeded;
    [SerializeField]
    int expandSize = 10;

    public void CreatePool(int poolSize = -1)
    {
        
        activePool = new List<T>();
        inactivePool = new List<T>();
        AddToPool(poolSize < 0 ? this.poolSize : poolSize);
    }
    protected virtual void AddToPool(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            AddObjToPool(objectPrefab);
        }
    }
    protected void AddObjToPool(T obj)
    {
        GameObject go = GameObject.Instantiate<GameObject>(obj.gameObject, this.transform);
        T objT = go.GetComponent<T>();
        objT.Init();
        inactivePool.Add(objT);
    }
    public T GetObject()
    {
        if (inactivePool.Count == 0 && expandIfNeeded)
        {
            AddToPool(expandSize);
        }
        if (inactivePool.Count == 0)
            return null;
        else
        {
            T inactiveObj = inactivePool[0];
            activePool.Add(inactiveObj);
            inactiveObj.gameObject.SetActive(true);
            inactiveObj.DespawnEvent += ReturnObject;
            inactivePool.RemoveAt(0);
            return inactiveObj;
        }
    }

    private void ReturnObject(IPoolable obj)
    {
        T objT = obj as T;
        if (activePool.Contains(objT))
        {
            objT.transform.SetParent(this.transform);
            objT.gameObject.SetActive(false);
            objT.DespawnEvent -= ReturnObject;
            activePool.Remove(objT);
            inactivePool.Add(objT);
        }
        else
        {
            Debug.LogError("Tired returning a non 'active' object to pool");
        }
    }

}


public interface IPoolable
{
    void Init(); //Called when Poolable object is created
    event Action<IPoolable> DespawnEvent; //Event needs to be call for object to become inactive in the pool
}