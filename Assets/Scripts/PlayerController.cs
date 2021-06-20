using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
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
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
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

public abstract class InputStrat {
    public abstract void Update();
}

public class TopDownInput : InputStrat
{
    public override void Update()
    {
       
        }
    }
}

