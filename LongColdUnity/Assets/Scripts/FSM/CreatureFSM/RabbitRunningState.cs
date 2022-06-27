using UnityEngine;

public class RabbitRunningState : IState
{

    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;
    private Creature creature;

    private float time = 0;
    private float thresholdTime;

    public IState handleInput(GameObject obj)
    {

        if (time >= thresholdTime)
        {
            thresholdTime = UpdateThresholdTime();
            time = 0;

            if (Random.Range(1, 3) == 2)
            {
                return new CreatureIdleState();
            }
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        thresholdTime = UpdateThresholdTime();

        rb = obj.GetComponent<Rigidbody2D>();
        animator = obj.GetComponent<Animator>();
        creature = obj.GetComponent<Creature>();

        animator.SetBool("isRunning", true);

        if (Random.value > .5) direction = Vector2.right;
        else direction = Vector2.left;

        var scale = obj.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction.x);
        obj.transform.localScale = scale;
    }

    public void OnExit()
    {
        animator.SetBool("isRunning", false);

    }

    public void Update()
    {
        rb.velocity = new Vector2(direction.x * creature.defaultSpeed, rb.velocity.y);
        time += Time.deltaTime;
        //Debug.Log($"{time} {thresholdTime}");
    }
    
    private float UpdateThresholdTime()
    {
        return Random.Range(2, 6);
    }
}
