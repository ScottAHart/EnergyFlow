using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class TowerController : MonoBehaviour
{
    [SerializeField] private TowerBattery battery = null;
    [SerializeField] private TowerGenerator generator = null;
    [SerializeField] private TowerGun gun = null;
    private void Start()
    {
        battery = this.GetComponent<TowerBattery>();
        generator = this.GetComponent<TowerGenerator>();
        if(generator != null)
            generator.GenerateEvent.AddListener(AddEnergy);
        gun = this.GetComponent<TowerGun>();
        if (gun != null)
            gun.ReadyToFireEvent.AddListener(FireGun);
    }



    public void AddEnergy(int amount)
    {
        if(battery != null)
            battery.AddEnergy(amount);
    }
    public bool RequestEnergy(int amount)
    {
        if (battery == null) return false;
        return battery.PullEnergy(amount);
    }
    public void FireGun()
    {
        if (gun == null) return;
        if (RequestEnergy(gun.EnergyNeeded))
            gun.Fire();
    }
}

