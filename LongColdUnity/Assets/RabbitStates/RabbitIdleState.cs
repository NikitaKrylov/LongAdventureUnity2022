using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitIdleState : IState<Rabbit>
{
    StateMachine<Rabbit> stateMachine;

    public RabbitIdleState(StateMachine<Rabbit> stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public IState<Rabbit> handleInput(Rabbit entity) => null;

    public void OnEnter(Rabbit entity)
    {

    }

    public void OnExit()
    {

    }

    public void Update()
    {

    }
}
