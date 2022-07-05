using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingState : IState
{
    private Animator animator;
    private GameObject gameObject;



    public IState handleInput(GameObject obj)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            return new StandingState();
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
