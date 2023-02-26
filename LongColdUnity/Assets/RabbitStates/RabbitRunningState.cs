using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitRunningState : IState<Rabbit>
{
    private Rabbit rabbit;

    public RabbitRunningState(StateMachine<Rabbit> stateMachine) { }

    public IState<Rabbit> handleInput(Rabbit entity)
    {
        return null;
    }

    public void OnEnter(Rabbit entity)
    {
        rabbit = entity;
        rabbit.animator.SetBool("isRunning", true);
    }

    public void OnExit()
    {
        rabbit.animator.SetBool("isRunning", false);

    }

    public void Update()
    {
        
    }
}
