using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitIdle : IState
{
    private FSM fsm;
    private Rabbit rabbit;
    private float time = 0; 
    private float targetTime = 0;

    private const float DETECT_ENEMY_DISTANCE = 4f;

    public RabbitIdle(FSM fsm)
    {
        this.fsm = fsm;
    }


    public IState handleInput(GameObject obj)
    {
        if (RabbitRunningAway.DetectEnemy(rabbit.transform, DETECT_ENEMY_DISTANCE) != null) return new RabbitRunningAway(fsm);

        else if (time >= targetTime)
        {
            return new RabbitWander(fsm);
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        rabbit = obj.GetComponent<Rabbit>();    
        rabbit.animator.SetBool("isRunning", false);    
        targetTime = Random.Range(2, 5);
    }

    public void OnExit() { }

    public void Update() => time += Time.deltaTime;

}
