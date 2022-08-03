using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingState : IState
{
    public ShiftingState(FSM fsm)
    {
        this.fsm = fsm;
    }

    private FSM fsm;
    private Animator animator;
    private GameObject gameObject;

    public IState handleInput(GameObject obj)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            return new StandingState(fsm);
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        gameObject = obj;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isShifting", true);
    }

    public void OnExit()
    {
        animator.SetBool("isShifting", false);

    }

    public void Update()
    {
    }
}
