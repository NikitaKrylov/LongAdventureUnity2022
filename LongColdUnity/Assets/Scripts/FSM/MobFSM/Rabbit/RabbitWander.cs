using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitWander : IState
{

    private Rabbit rabbit;
    private Vector2 direction;
    private FSM fsm;
    private float time = 0;
    private float targetTime = 0;

    private const float DETECT_ENEMY_DISTANCE = 4;
   
    public RabbitWander(FSM fsm)
    {
        this.fsm = fsm; 
    }

    public IState handleInput(GameObject obj)
    {
        if (RabbitRunningAway.DetectEnemy(rabbit.transform, DETECT_ENEMY_DISTANCE) != null) return new RabbitRunningAway(fsm);

        else if (time >= targetTime)
        {
            return new RabbitIdle(fsm);
        }
        return null;    
    }

    public void OnEnter(GameObject obj)
    {
        rabbit = obj.GetComponent<Rabbit>();
        rabbit.animator.SetBool("isRunning", true);
        targetTime = Random.Range(3, 7);
        
        if (Random.value > .5f) direction = Vector2.right;
        else direction = Vector2.left;

        var scale = rabbit.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction.x);
        rabbit.transform.localScale = scale;
    }

    public void OnExit()
    {
        rabbit.animator.SetBool("isRunning", true);
    }


    public void Update()
    {
        time += Time.deltaTime; 
        rabbit.Move(new Vector2(rabbit.GetDefaultSpeed(), 0), direction);
    }
}
