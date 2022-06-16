using UnityEngine;

public class FSM : MonoBehaviour
{
    public IState currentState;
    void Start()
    {
        currentState = new StandingState(gameObject);
    }

    void Update()
    {
        currentState.Update();

        var state = currentState.handleInput(gameObject);
        if (state != null)
        {
            currentState.OnExit();
            currentState = state;
        }
        
    }
    public void SetState(IState state)
    {
        if (state != null ) currentState = state;
    }
}
