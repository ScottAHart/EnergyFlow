using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : GameState
{
    private const string SCENENAME = "Menu";
    public override async Task OnEnter(GameState previous = null)
    {
        Debug.Log("Entered Menu");
        //MOVE TO LOADER 
        AsyncOperation load = SceneManager.LoadSceneAsync(SCENENAME);

        while (!load.isDone)
            await new WaitForUpdate();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SCENENAME));
        await GameMachine.Instance.Loading.Deactive();
        Debug.Log("Menu Ready");
    }
    public override Task OnExit(GameState next = null)
    {
        Debug.Log("Exit Menu");
        return Task.CompletedTask;
    }
    public override void FixedUpdate(float fixedDeltaTime)
    {
    }
    public override void Update(float deltaTime)
    {
    }

    public void Play()
    {
        GameMachine.Instance.NewState(new TestGameState());
    }
}
