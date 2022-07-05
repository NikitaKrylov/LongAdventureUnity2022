using UnityEngine;

public class StandingState : IState
{
    private FSM weaponFSM;
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
        else if (Input.GetKeyDown(KeyCode.J))
        {
            return new ClimbingState();
        }
        else if (FallingState.isFalling(obj))
        {
            return new FallingState();
        }
        else if (Input.GetMouseButtonDown(0) && !(weaponFSM.currentState is NoWeaponState))
        {
            return new HitState();
        }
        return null;
    }

    public void OnEnter(GameObject gameObject)
    {
        weaponFSM = gameObject.GetComponent<Player>().WeaponFSM;
    }
    public void Update(){}
    public void OnExit(){}
}
