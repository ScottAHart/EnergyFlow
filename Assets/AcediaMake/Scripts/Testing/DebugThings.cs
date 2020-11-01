using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DebugMore
{
    public static void DrawCross(Vector3 point, float size = 0.5f, Color? colour = null, float duration = 10.0f)
    {
        //Debug.LogError("Drawing Cross");
        Debug.DrawLine(point + Vector3.forward * size / 2, point + Vector3.back * size / 2, colour.GetValueOrDefault(Color.red), duration);
        Debug.DrawLine(point + Vector3.up * size / 2, point + Vector3.down * size / 2, colour.GetValueOrDefault(Color.red), duration);
        Debug.DrawLine(point + Vector3.left * size / 2, point + Vector3.right * size / 2, colour.GetValueOrDefault(Color.red), duration);
    }

    public static void DrawCircle(Vector3 point, Vector3 forward, float radius = 0.5f, Color? colour = null, float duration = 10.0f, int segments = 50)
    {
        Debug.LogError("Drawing Circle");

        for(int i =0; i < segments; i++)
        {
            //>_>
        }
    }
}
