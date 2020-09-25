using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestGameState : GameState
{
    public override void FixedUpdate(float fixedDeltaTime)
    {
    }

    public override async Task OnEnter(GameState previous = null)
    {
        await GameMachine.Instance.Loading.Activate();
        await SceneManager.LoadSceneAsync(2);
        //Do game stuff ui etc

        await GameMachine.Instance.Loading.Deactive();
        
    }

    public override Task OnExit(GameState next = null)
    {
        return null;
    }

    public override void Update(float deltaTime)
    {
    }

}
