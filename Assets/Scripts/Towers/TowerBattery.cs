using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerController)), DisallowMultipleComponent]
public class TowerBattery : MonoBehaviour
{   
    [SerializeField] int storageCap = 100;
    [SerializeField] int currentStored = 0;
    [SerializeField] int transferAmount = 10;
    /// <summary>
    /// Add energy to battery
    /// </summary>
    /// <param name="amount">Try and add</param>
    /// <returns>Amount of energy remaning</returns>
    public int AddEnergy(int amount) 
    {
        if(currentStored < storageCap)
        {
            int toAdd = Mathf.Min(amount, transferAmount);
            if (toAdd + currentStored > storageCap)
                toAdd = storageCap - currentStored;
            currentStored += toAdd;
            return amount - toAdd;
        }
        else
        {
            return amount;
        }
    }
    public bool PullEnergy(int reqAmount)
    {
        if (currentStored > reqAmount)
        {
            currentStored -= reqAmount;
            return true;
        }
        else
        {
            return false;
        }
    }
}
