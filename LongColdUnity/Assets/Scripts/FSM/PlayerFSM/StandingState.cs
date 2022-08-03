using UnityEngine;

public class StandingState : IState
{
    public StandingState(FSM fsm)
    {
        this.fsm = fsm;
    }

    private FSM fsm;
    private FSM weaponFSM;
    public IState handleInput(GameObject obj)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > .3)
        {
            return new WalkingState(fsm);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            return new SleepingState(fsm);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            return new ShiftingState(fsm);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            return new ClimbingState(fsm);
        }
        else if (FallingState.isFalling(obj))
        {
            return new FallingState(fsm);
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
