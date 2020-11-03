using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IPoolable
{
    public event Action<IPoolable> DespawnEvent;
    private NavMeshAgent navAgent = null;
    public void Init()
    {
        Debug.Log("Enemy Init");
        this.gameObject.SetActive(false);
        
    }
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        Debug.Log("Enemy Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy Start");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, navAgent.destination) <= 0.2f)
        {
            Despawn();
        }
    }

    public void Spawn(Transform spawnPos, Transform goalPos)
    {
        this.transform.position = spawnPos.position;
        this.transform.rotation = spawnPos.rotation;
        navAgent.Warp(spawnPos.position);
        navAgent.SetDestination(goalPos.position);
    }

    public void Despawn()
    {
        DespawnEvent.Invoke(this);
    }
}
