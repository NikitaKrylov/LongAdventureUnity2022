using UnityEngine;
using UnityEngine.Tilemaps;

public class StateMachine<T> where T: MonoBehaviour
{

    public IState<T> currentState;
    public IState<T> lastState;
    public T entity;

    public StateMachine(T entity, IState<T> state)
    {
        this.entity = entity;
        InitState(state);
    }

    public void Update()
    {
        currentState.Update();

        IState<T> state = currentState.handleInput(entity);
        SetState(state);
    }

    public void SetState(IState<T> state)
    {
        if (state == null) return;
        currentState.OnExit();
        lastState = currentState;
        currentState = state;
        currentState.OnEnter(entity);
    }
    private void InitState(IState<T> state)
    {
        lastState = null;
        currentState = state;
        currentState.OnEnter(entity);

    }

    
}
