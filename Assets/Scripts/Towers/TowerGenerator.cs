using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerController))]

public class TowerGenerator : MonoBehaviour
{
    TowerController tc = null;

    [SerializeField] float generationTime = 3f;
    [SerializeField] int generationAmount = 10;

    float genTimer = 0;

    private void Start()
    {
        tc = GetComponent<TowerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (genTimer > generationTime)
        {
            genTimer = 0;
            tc.AddEnergy(generationAmount);
        }
        else
        {
            genTimer += Time.deltaTime;
        }
    }
}
