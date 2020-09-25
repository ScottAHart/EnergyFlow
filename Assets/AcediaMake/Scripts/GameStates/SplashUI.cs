using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SplashUI : MonoBehaviour, IUI
{
    [SerializeField]
    CanvasGroup teamLogo = null;
    [SerializeField]
    CanvasGroup gameLogo = null;

    [SerializeField]
    float timeForTeam = 3;
    [SerializeField]
    float fadeTime = 1;

    private void Awake()
    {
        teamLogo.gameObject.SetActive(false);
        gameLogo.gameObject.SetActive(false);
    }
    public async Task Hide()
    {
        await gameLogo.LerpAlpha(1, 0, fadeTime);
        gameLogo.gameObject.SetActive(false);
    }


    public async Task Show()
    {
        teamLogo.gameObject.SetActive(true);
        await teamLogo.LerpAlpha(0, 1, fadeTime);
        await Task.Delay((int)(timeForTeam * 1000));
        //Lerp alpha
        await teamLogo.LerpAlpha(1, 0, fadeTime);
        teamLogo.gameObject.SetActive(false);
        gameLogo.gameObject.SetActive(true);
        await gameLogo.LerpAlpha(0, 1, fadeTime);
        await Task.Delay((int)(timeForTeam * 1000));
    }
}
