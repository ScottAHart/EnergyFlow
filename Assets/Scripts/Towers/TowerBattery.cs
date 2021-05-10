using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerController))]
public class TowerBattery : MonoBehaviour, ITowerPart
{
    [SerializeField] float storageCap = 100f;
    [SerializeField] float currentStored = 0f;

    public void Breakdown()
    {
    }

    public void SetUp(TowerController controller)
    {
    }
}
