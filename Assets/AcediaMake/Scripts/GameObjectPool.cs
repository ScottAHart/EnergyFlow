using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectPooler<T> : MonoBehaviour where T: MonoBehaviour, IPoolable{

    [SerializeField]
    private int poolSize = 10;

    [SerializeField]
    private List<T> pool = new List<T>();

    [SerializeField]
    private T objectPrefab;

    private void Awake()
    {
        if (objectPrefab != null)
            CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++) {
            GameObject go = GameObject.Instantiate<GameObject>(objectPrefab.gameObject);
            T objT = go.GetComponent<T>();
            pool.Add(objT);
        }
    }
}


public interface IPoolable
{
    void Spawn();
    void Despawn();
}
