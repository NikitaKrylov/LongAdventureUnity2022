using UnityEngine;

public class SleepingState : IState<Player>
{
    public SleepingState(StateMachine<Player> fsm)
    {
        this.fsm = fsm;
    }

    private StateMachine<Player> fsm;
    private bool canSkip = true;
    private GameObject gameObject;
    private Animator animator;


    public IState<Player> handleInput(Player player)
    {
        if (!canSkip) return null;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.U))
        {
            return new StandingState(fsm);
        }
        return null;
    }

    public void OnEnter(Player player)
    {
        gameObject = player.gameObject;
        animator = gameObject.GetComponent<Animator>();


        animator.SetBool("isSleeping", true);
    }
    public void OnExit()
    {
        animator.SetBool("isSleeping", false);
    }
    public void Update(){}
}
