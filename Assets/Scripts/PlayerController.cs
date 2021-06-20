using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour, IHittable
{
    InputStrat inputStrat;
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        if (navMeshAgent == null) navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000, LayerMask.GetMask("Ground")))
            {
                if (hitInfo.transform.tag == "Ground")
                {
                    navMeshAgent.SetDestination(hitInfo.point);

                }
                else
                {

                }
            }
        }

    }
    public bool Hit(int amount)
    {
        Debug.Log("Hit", this);
        return false;
    }
}



public abstract class InputStrat {
    public abstract void Update();
}

public class TopDownInput : InputStrat
{
    public override void Update()
    {


    }
}

