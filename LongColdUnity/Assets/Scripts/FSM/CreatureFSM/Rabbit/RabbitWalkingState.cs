using UnityEngine;

public class RabbitWalkingState : BaseRabbitState
{

    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;


    public override IState handleInput(GameObject obj)
    {
        if (DetectPlayer(detectRadius) != null)
        {
            return new RabbitRunningAwayState();
        }
        else if (time >= thresholdTime)
        {
            thresholdTime = GetRandomTime();
            time = 0;

            if (Random.Range(1, 3) == 2)
            {
                return new RabbitIdleState();
            }
        }
        return null;
    }

    public override void OnEnter(GameObject obj)
    {
        base.OnEnter(obj);
        thresholdTime = GetRandomTime();
        rb = obj.GetComponent<Rigidbody2D>();
        animator = obj.GetComponent<Animator>();

        animator.SetBool("isRunning", true);

        if (Random.value > .5) direction = Vector2.right;
        else direction = Vector2.left;

        var scale = obj.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction.x);
        obj.transform.localScale = scale;
    }

    public override void OnExit()
    {
        animator.SetBool("isRunning", false);

    }

    public override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(direction.x * creature.defaultSpeed, rb.velocity.y);
    }
    
    
}
