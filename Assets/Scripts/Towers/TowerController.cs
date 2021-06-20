using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class TowerController : MonoBehaviour
{
    [SerializeField] private TowerBattery battery = null;
    private void Start()
    {
        battery = this.GetComponent<TowerBattery>();
    }
    public void AddEnergy(int amount)
    {
        battery.AddEnergy(amount);
    }
    public int RequestEnergy(int amount)
    {
        return battery.PullEnergy(amount);
    }
}

