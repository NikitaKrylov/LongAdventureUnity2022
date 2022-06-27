using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureIdleState : IState
{
    private Animator animator;
    private float time = 0;
    private float thresholdTime;


    public IState handleInput(GameObject obj)
    {
        if (time >= thresholdTime)
        {
            time = 0;
            thresholdTime = UpdateThresholdTime();
            return new RabbitRunningState();
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        animator = obj.GetComponent<Animator>();
        //animator.SetBool("isIdle", true);
        thresholdTime = UpdateThresholdTime();

    }

    public void OnExit()
    {
        //animator.SetBool("isIdle", false);
    }

    public void Update()
    {
        time += Time.deltaTime;
    }
    private float UpdateThresholdTime()
    {
        return Random.Range(3, 8);
    }
}
