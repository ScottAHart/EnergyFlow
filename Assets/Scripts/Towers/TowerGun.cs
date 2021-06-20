using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerController)), DisallowMultipleComponent]
public class TowerGun : MonoBehaviour
{
    [SerializeField] int energyNeeded = 5;
    [SerializeField] int fireRate = 1;
    [SerializeField] int damage = 1;
    int tempCap = 0;
    float fireTimer = 0;
    private IHittable target = null;
    private List<IHittable> possibleTargets = new List<IHittable>();
    TowerController tc = null;
    void Start()
    {
        tc = GetComponent<TowerController>();
    }
    void Update()
    {
        if (target != null)
        {
            if (fireTimer > fireRate)
            {
                int pullAmount = tc.RequestEnergy(energyNeeded - tempCap);
                if ((pullAmount + tempCap) >= energyNeeded)
                {
                    tempCap = 0;
                    Fire();
                }
                else
                {
                    tempCap += pullAmount;
                    fireTimer = 0;
                }
            }
            else
            {
                fireTimer += Time.deltaTime;
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        IHittable hittable = other.GetComponent<IHittable>();
        if (other.tag != "Tower" && hittable != null)
        {
            if (target == null)
            {
                target = hittable;
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
            if (target == hittable)
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
            possibleTargets.Remove(target);
        }
        else
        {
            SetTarget(null);
        }
    }
    private void SetTarget(IHittable hitable)
    {
        target = hitable;
        fireTimer = 0;
    }
    private void Fire()
    {
        Debug.Log("Fire Gun - ", this);
        fireTimer = 0;
        if (target.Hit(damage))
        {
            NextTarget();
        }
    }
}
