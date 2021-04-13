using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    Transform endPoint;

    [SerializeField]
    BotPool testEnemyPool;
    //EnemyPool ePool2; ect

    private void Awake()
    {
        testEnemyPool.CreatePool(10);
        timer = Time.time;
    }
    [ContextMenu("SpawnTest")]
    public void TestSpawn()
    {
        LaneBot newEnemy = testEnemyPool.GetObject();
        if (newEnemy == null) return;
        newEnemy.Spawn(spawnPoint.transform, endPoint);
    }


    float timer = 0;
    float spawnTime = 3;
    private void Update()
    {
        if (Time.time - timer > spawnTime)
        {
            TestSpawn();
            timer = Time.time;
        }
    }
}
