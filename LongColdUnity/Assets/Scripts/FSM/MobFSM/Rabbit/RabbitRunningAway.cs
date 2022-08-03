using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitRunningAway : IState
{
    private Rabbit rabbit;
    private Vector2 direction = Vector2.zero;
    private FSM fsm;

    private const float RAYCAST_DISTANCE = 5.7f;
    public RabbitRunningAway(FSM fsm)
    {
        this.fsm = fsm;
    }
    public IState handleInput(GameObject obj)
    {
        if (DetectEnemy(rabbit.transform, RAYCAST_DISTANCE) == null) return new RabbitIdle(fsm);

        return null;
    }

    public void OnEnter(GameObject obj)
    {
        rabbit = obj.GetComponent<Rabbit>();
        rabbit.animator.SetBool("isRunning", true);
    }

    public void OnExit()
    {
        rabbit.animator.SetBool("isRunning", false);
    }

    public void Update()
    {
        GameObject obj = DetectEnemy(rabbit.transform, RAYCAST_DISTANCE);
        if (obj == null) return;

        direction.x = Mathf.Sign(rabbit.transform.position.x - obj.transform.position.x);

        var scale = rabbit.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction.x);
        rabbit.transform.localScale = scale;

        rabbit.Move(new Vector2(rabbit.GetMaxSpeed(), 0), direction);
    }

    public static GameObject DetectEnemy(Transform transform, float distance)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, distance, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.gameObject.CompareTag("Player")) return hit.transform.gameObject;
        }
        return null;
    }
}
