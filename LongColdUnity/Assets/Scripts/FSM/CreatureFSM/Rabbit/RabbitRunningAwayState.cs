using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitRunningAwayState : BaseRabbitState
{
    private GameObject playerObj;
    private Rigidbody2D rb;
    private Vector2 direction;
    private GameObject gameObject;
    private Animator animator;

    public override IState handleInput(GameObject obj)
    {
        playerObj = DetectPlayer(maxDetectRadius);

        if (playerObj == null)
        {
            return new RabbitIdleState();
        }
        return null;
    }

    public override void OnExit()
    {
        animator.SetBool("isRunning", false);
    }
    public override void OnEnter(GameObject obj)
    {
        base.OnEnter(obj);

        playerObj = DetectPlayer(maxDetectRadius);
        rb = obj.GetComponent<Rigidbody2D>();
        gameObject = obj;
        animator = obj.GetComponent<Animator>();
        animator.SetBool("isRunning", true);

    }
    public override void Update()
    {
        base.Update();

        if (playerObj.transform.position.x > gameObject.transform.position.x) direction.x = -1;
        else direction.x = 1;

        rb.velocity = new Vector2(direction.x * creature.defaultSpeed * 2.5f, rb.velocity.y);

        var scale = gameObject.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction.x);
        gameObject.transform.localScale = scale;

    }


}
