using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerController)), DisallowMultipleComponent]
public class TowerGun : MonoBehaviour, ITowerGun
{
    [SerializeField] int energyNeeded = 5;
    public int EnergyNeeded() => energyNeeded;
    [SerializeField] int fireRate = 1;
    [SerializeField] int damage = 1;


    public event UnityAction ReadyToFireEvent;

    float fireTimer = 0;
    private IHittable currentTarget = null;
    private List<IHittable> possibleTargets = new List<IHittable>();
    

    void Update()
    {
        if (currentTarget != null)
        {
            if (fireTimer < fireRate)
            {
                fireTimer += Time.deltaTime;
                if (fireTimer >= fireRate)
                    ReadyToFireEvent.Invoke();
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        IHittable hittable = other.GetComponent<IHittable>();
        if (other.tag != "Tower" && hittable != null)
        {
            if (currentTarget == null)
            {
                currentTarget = hittable;
            }
            else
            {
                if (!possibleTargets.Contains(hittable))
                {
                    possibleTargets.Add(hittable);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        IHittable hittable = other.GetComponent<IHittable>();
        if (other.tag != "Tower" && hittable != null)
        {
            if (currentTarget == hittable)
            {
                NextTarget();
            }
            else
            {
                if (possibleTargets.Contains(hittable))
                {
                    possibleTargets.Remove(hittable);
                }
            }
        }
    }
    private void NextTarget()
    {
        if (possibleTargets.Count > 0)
        {
            SetTarget(possibleTargets[0]);
            possibleTargets.Remove(currentTarget);
        }
        else
        {
            SetTarget(null);
        }
    }
    private void SetTarget(IHittable hitable)
    {
        currentTarget = hitable;
        fireTimer = 0;
    }
    //public void SetTarget(Vector3 pos)
    //{

    //}
    public void Fire()
    {
        Debug.Log("Tower gun fire", this);
        fireTimer = 0;
        if (currentTarget.Hit(damage))
        {
            NextTarget();
        }
    }
}

public interface ITowerGun : ITowerAction
{
    event UnityAction ReadyToFireEvent;
    void Fire();
}
