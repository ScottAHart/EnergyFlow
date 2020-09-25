using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class Exenstions
{
    public static async Task LerpAlpha(this CanvasGroup group, float from, float to, float time)
    {
        float start = 0;
        group.alpha = from;
        while (group.alpha != to)
        {
            group.alpha = Mathf.Lerp(from, to, start / time);
            start += Time.deltaTime;
            await new WaitForUpdate();
        }
        group.alpha = to;
    }
}
