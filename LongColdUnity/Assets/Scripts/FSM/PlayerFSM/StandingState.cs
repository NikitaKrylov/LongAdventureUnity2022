using UnityEngine;

public class StandingState : IState
{
    public IState handleInput(GameObject obj)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > .3)
        {
            return new RunningState();
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            return new SleepingState();
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            return new ShiftingState();
        }
        else if (FallingState.isFalling(obj))
        {
            return new FallingState();
        }
        return null;
    }

    public void OnEnter(GameObject gameObject){}
    public void Update(){}
    public void OnExit(){}
}
