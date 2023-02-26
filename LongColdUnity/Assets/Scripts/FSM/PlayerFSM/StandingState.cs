using UnityEngine;

public class StandingState : IState<Player>
{
    public StandingState(StateMachine<Player> fsm)
    {
        this.fsm = fsm;
    }

    private StateMachine<Player> fsm;
    public IState<Player> handleInput(Player player)
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
        else if (FallingState.isFalling(player.gameObject))
        {
            return new FallingState(fsm);
        }
        
        return null;
    }

    public void Update(){}
    public void OnExit(){}

    public void OnEnter(Player player) { }
    
}
