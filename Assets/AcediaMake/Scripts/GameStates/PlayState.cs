using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayState : GameState
{
    public override Task OnEnter(GameState previous = null)
    {
        Debug.Log("Entered Play");
        return Task.CompletedTask;
    }
    public override Task OnExit(GameState next = null)
    {
        Debug.Log("Exit Play");
        return Task.CompletedTask;
    }
    public override void FixedUpdate(float fixedDeltaTime)
    {
        Debug.Log("Play Fixed update");
    }
    public override void Update(float deltaTime)
    {
        Debug.Log("Play Update");
    }
}
