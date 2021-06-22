using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTransmitter : MonoBehaviour
{
    [SerializeField] TowerController otherTower;
    public TowerController OtherTower => otherTower;

    public bool PullEnergy(int amount, TowerController source)
    {
        Debug.Log("Pull Energy");
        if (otherTower != source)
            return otherTower.PullEnergy(amount);
        else
        {
            Debug.Log("Cyclic Pull");
            return false;
        }
    } 
}
