using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerController))]
public class TowerBattery : MonoBehaviour
{   
    [SerializeField] int storageCap = 100;
    [SerializeField] int currentStored = 0;
    [SerializeField] int maxAddAmount = 10;
    /// <summary>
    /// Add energy to battery
    /// </summary>
    /// <param name="amount">Try and add</param>
    /// <returns>Amount of energy remaning</returns>
    public int AddEnergy(int amount) 
    {
        if(currentStored < storageCap)
        {
            int toAdd = Mathf.Min(amount, maxAddAmount);
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
    public int PullEnergy(int reqAmount)
    {
        if (currentStored > 0)
        {
            if (currentStored > reqAmount)
            {
                currentStored -= reqAmount;
                return reqAmount;
            }
            else
            {
                int cur = currentStored;
                currentStored = 0;
                return cur;
            }
        }
        else
        {
            return 0;
        }
    }
}
