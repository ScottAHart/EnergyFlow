using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InitalState : GameState
{
    private const string SCENENAME = "InitalScene";
    SplashUI splash;
    public override async Task OnEnter(GameState previous = null)
    {
        Debug.Log("Entered Inital");

        await GameMachine.Instance.Loading.Deactive();
        splash = GameObject.FindObjectOfType<SplashUI>();
        if (splash == null) throw new System.Exception("Splash UI not found in current scene");
        await splash.Show();
        GameMachine.Instance.NewState(new MenuState());
    }
    
    public override async Task OnExit(GameState next = null)
    {
        await Task.WhenAll(splash.Hide(), GameMachine.Instance.Loading.Activate());
        // await SceneManager.UnloadSceneAsync(SCENENAME);
        Debug.Log("Exit Inital");
    }
    public override void FixedUpdate(float fixedDeltaTime)
    {
    }
    public override void Update(float deltaTime)
    {
    }
}
