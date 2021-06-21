using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(TowerController)), DisallowMultipleComponent]

public class TowerGenerator : MonoBehaviour
{
    [SerializeField] float generationTime = 3f;
    [SerializeField] int generationAmount = 10;

    float genTimer = 0;

    private UnityEvent<int> generateEvent = new UnityEvent<int>();
    public UnityEvent<int> GenerateEvent => generateEvent;

    // Update is called once per frame
    void Update()
    {
        if (genTimer > generationTime)
        {
            genTimer = 0;
            generateEvent.Invoke(generationAmount);
        }
        else
        {
            genTimer += Time.deltaTime;
        }
    }
}
