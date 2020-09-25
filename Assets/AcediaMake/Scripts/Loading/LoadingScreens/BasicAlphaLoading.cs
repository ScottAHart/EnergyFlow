using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BasicAlphaLoading : LoadingScreen
{
    [SerializeField]
    CanvasGroup fadingCanvasGroup = null;

    [SerializeField]
    float fadeTime = 2.0f; //Seconds
    public async override Task Activate()
    {
        if (fadingCanvasGroup.gameObject.activeSelf == true) return;
        fadingCanvasGroup.gameObject.SetActive(true);
        await fadingCanvasGroup.LerpAlpha(0, 1, fadeTime);
    }

    public async override Task Deactivate()
    {
        if (fadingCanvasGroup.gameObject.activeSelf == false) return;
        await fadingCanvasGroup.LerpAlpha(1, 0, fadeTime);
        fadingCanvasGroup.gameObject.SetActive(false);
    }
}
