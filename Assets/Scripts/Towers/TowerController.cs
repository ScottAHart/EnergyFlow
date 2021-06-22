using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class TowerController : MonoBehaviour
{
    [SerializeField] private TowerBattery battery = null;
    [SerializeField] private TowerGenerator generator = null;
    [SerializeField] private TowerGun gun = null;
    [SerializeField] private TowerTransmitter transmitter = null;
    [SerializeField] bool autoFire = true;
    private void Start()
    {
        battery = this.GetComponentInChildren<TowerBattery>();
        generator = this.GetComponentInChildren<TowerGenerator>();
        if(generator != null)
            generator.GenerateEvent.AddListener(AddEnergy);

        gun = this.GetComponentInChildren<TowerGun>();
        if (gun != null)
            gun.ReadyToFireEvent.AddListener(FireGun);

        transmitter = this.GetComponentInChildren<TowerTransmitter>();

    }



    public void AddEnergy(int amount)
    {
        if(battery != null)
            battery.AddEnergy(amount);
    }
    public bool PullEnergy(int amount, TowerController source = null)
    {
        if (source == null) source = this;

        bool pulled = false;
        if (battery != null)
            pulled = battery.PullEnergy(amount);
        if (!pulled)
            if (transmitter != null)
                pulled = transmitter.PullEnergy(amount, source);

        return pulled;
    }
    public void FireGun()
    {
        if (gun == null) return;
        if (PullEnergy(gun.EnergyNeeded))
            gun.Fire();
    }
}

