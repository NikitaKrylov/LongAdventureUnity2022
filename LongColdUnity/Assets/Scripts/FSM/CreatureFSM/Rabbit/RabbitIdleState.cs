using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitIdleState : BaseRabbitState
{
    private Animator animator;


    public override IState handleInput(GameObject obj)
    {
        if (DetectPlayer(detectRadius) != null)
        {
            return new RabbitRunningAwayState();
        }
        else if (time >= thresholdTime)
        {
            time = 0;
            thresholdTime = GetRandomTime();
            return new RabbitWalkingState();
        }

        return null;
    }

    public override void OnEnter(GameObject obj)
    {
        base.OnEnter(obj);
        animator = obj.GetComponent<Animator>();
        //animator.SetBool("isIdle", true);
        thresholdTime = GetRandomTime();

    }

    public override void OnExit()
    {
        //animator.SetBool("isIdle", false);
    }


}
