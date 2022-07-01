using UnityEngine;
using UnityEngine.Tilemaps;

public class FSM
{

    public IState currentState;
    public IState lastState;
    public GameObject gameObject;

    public FSM(GameObject gameObject ,IState state)
    {
        this.gameObject = gameObject;
        InitState(state);
    }

    public void Update()
    {
        currentState.Update();

        IState state = currentState.handleInput(gameObject);
        SetState(state);
    }

    public void SetState(IState state)
    {
        if (state == null) return;
        currentState.OnExit();
        lastState = currentState;
        currentState = state;
        currentState.OnEnter(gameObject);
    }
    private void InitState(IState state)
    {
        lastState = null;
        currentState = state;
        currentState.OnEnter(gameObject);

    }

    
}
