using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class PathCreation : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit raycastHit, 1000.0f /*,LayerMask.GetMask("Ground")*/))
            {
                DebugMore.DrawCross(raycastHit.point);
            }
        }
    }

}
