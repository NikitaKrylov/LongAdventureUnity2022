using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingState : IState<Player>
{
    public ShiftingState(StateMachine<Player> fsm)
    {
        this.fsm = fsm;
    }

    private StateMachine<Player> fsm;
    private Animator animator;
    private GameObject gameObject;

    public IState<Player> handleInput(Player player)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            return new StandingState(fsm);
        }
        return null;
    }

    public void OnEnter(Player player)
    {
        gameObject = player.gameObject;
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
