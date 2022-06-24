using UnityEngine;
using UnityEngine.Tilemaps;

public class FSM
{

    public IState currentState;
    public GameObject gameObject;

    public FSM(GameObject gameObject ,IState currentState)
    {
        this.currentState = currentState;
        this.gameObject = gameObject;
    }

    public void Update()
    {
        currentState.Update();

        IState state = currentState.handleInput(gameObject);
        ChangeState(state);
    }

    public void ChangeState(IState state)
    {
        if (state == null) return;
        currentState.OnExit();
        currentState = state;
        currentState.OnEnter(gameObject);
    }

    
}
