using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private List<TowerBattery> batteries = new List<TowerBattery>();
    private void Start()
    {
        batteries = new List<TowerBattery>(this.GetComponents<TowerBattery>());
    }
    public void AddEnergy(int amount)
    {
        int amountLeft = amount;
        foreach(var bat in batteries)
        {
            amountLeft = bat.AddEnergy(amountLeft);
        }
    }
    public int RequestEnergy(int amount)
    {
        return 0;
    }
}

