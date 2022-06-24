using UnityEngine;

public class StandingState : IState
{
    public IState handleInput(GameObject obj)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > .3)
        {
            return new RunningState(obj);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            return new SleepingState(obj);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            return new ShiftingState(obj);
        }
        else if (FallingState.isFalling(obj))
        {
            return new FallingState(obj);
        }
        return null;
    }

    public StandingState(GameObject obj)
    {
        OnEnter(obj);
    }

    public void OnEnter(GameObject gameObject){}
    public void Update(){}
    public void OnExit(){}
}
