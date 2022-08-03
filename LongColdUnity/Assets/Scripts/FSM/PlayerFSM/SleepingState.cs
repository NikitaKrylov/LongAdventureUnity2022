using UnityEngine;

public class SleepingState : IState
{
    public SleepingState(FSM fsm)
    {
        this.fsm = fsm;
    }

    private FSM fsm;
    private bool canSkip = true;
    private GameObject gameObject;
    private Animator animator;


    public IState handleInput(GameObject obj)
    {
        if (!canSkip) return null;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.U))
        {
            return new StandingState(fsm);
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        gameObject = obj;
        animator = gameObject.GetComponent<Animator>();


        animator.SetBool("isSleeping", true);
    }
    public void OnExit()
    {
        animator.SetBool("isSleeping", false);
    }
    public void Update(){}
}
