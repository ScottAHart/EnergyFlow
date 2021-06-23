using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
[DisallowMultipleComponent]
public class TowerController : MonoBehaviour
{
    [SerializeField] private TowerBattery battery = null;
    [SerializeField] private TowerGenerator generator = null;
    [SerializeField] private ITowerGun gun = null;
    [SerializeField] private TowerTransmitter transmitter = null;
    [SerializeField] private float retryTimer = 1f;
    //[SerializeField] bool autoFire = true;
    private void Start()
    {
        battery = this.GetComponentInChildren<TowerBattery>();
        generator = this.GetComponentInChildren<TowerGenerator>();
        if(generator != null)
            generator.GenerateEvent.AddListener(AddEnergy);

        gun = this.GetComponentInChildren<ITowerGun>();
        if (gun != null)
            gun.ReadyToFireEvent += FireGun;

        transmitter = this.GetComponentInChildren<TowerTransmitter>();

    }
    private void OnDestroy()
    {
        if (gun != null)
            gun.ReadyToFireEvent -= FireGun;
        if (generator != null)
            generator.GenerateEvent.RemoveListener(AddEnergy);
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
        if (PullEnergy(gun.EnergyNeeded()))
            gun.Fire();
    }
    async Task RetryTask(float time, UnityAction action)
    {
        int floatTomiliSeconds = (int)(time * 10);
        await Task.Delay(floatTomiliSeconds);
        action.Invoke();
        return;
    }
}

public interface ITowerAction
{
    int EnergyNeeded();
}

