using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameMachine : MonoBehaviour
{
    [System.Serializable]
    public enum State
    {
        Inital,
        Menu,
        Level,
    }
    private GameState currentState;
    public GameState Current => currentState;
    private static GameMachine instance;
    public static GameMachine Instance => instance;
    [SerializeField]
    private State startState = State.Inital;
    private GameState initalState;
    private Loading loading;
    public Loading Loading => loading;

    private void Awake()
    {
        if (GameMachine.Instance == null && GameMachine.Instance != this)
        {
            instance = this;
            loading = FindObjectOfType<Loading>();
            initalState = CreateState(startState);
            ForceState(initalState);
        }
        else
            Destroy(gameObject);
    }
    

    private void Update()
    {
        if (currentState == null)
            throw new System.NullReferenceException("State was not set up");
        currentState.Update(Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (currentState == null)
            throw new System.NullReferenceException("State was not set up");
        currentState.FixedUpdate(Time.fixedDeltaTime);
    }

    public async void NewState(GameState newState)
    {
        if (newState == null)
            throw new System.ArgumentNullException("newState");
        GameState oldState = currentState;
        currentState = newState;
        await oldState?.OnExit(newState);
        await newState.OnEnter(oldState);
    }
    //Like new state but doesn't await from enter/exits before setting current state
    public void ForceState(GameState newState)
    {
        if (newState == null)
            throw new System.ArgumentNullException("newState");
        GameState oldState = currentState;
        currentState = newState;
        oldState?.OnExit(newState).WrapErrors();
        newState.OnEnter(oldState).WrapErrors();
    }

    public static GameState CreateState(State state)
    {
        switch (state)
        {
            case State.Inital:
                return new InitalState();
            case State.Menu:
                return new MenuState();
            case State.Level:
                return null;
        }
        return null;
    }
}
public abstract class GameState
{
    public abstract Task OnEnter(GameState previous = null);
    public abstract void Update(float deltaTime);
    public abstract void FixedUpdate(float fixedDeltaTime);
    public abstract Task OnExit(GameState next = null);
}
