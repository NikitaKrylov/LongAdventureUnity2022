using UnityEngine;

public class WalkingState : IState<Player>
{
    public WalkingState(StateMachine<Player> fsm)
    {
        this.fsm = fsm;
    }

    private StateMachine<Player> fsm;
    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D _rb;
    private Animator animator;
    private GameObject gameObject;
    private Player player;


    public IState<Player> handleInput(Player player)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < .3) return new StandingState(fsm);

        else if (Mathf.Abs(Input.GetAxis("Horizontal")) > .3 && Input.GetKey(KeyCode.LeftControl)) return new RunningState(fsm);

        else if (Input.GetKey(KeyCode.LeftShift)) return new ShiftingState(fsm);

        else if (FallingState.isFalling(player.gameObject)) return new FallingState(fsm);


        return null;
    }

    public void OnEnter(Player palyer)
    {
        gameObject = palyer.gameObject;
        player = gameObject.GetComponent<Player>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }

    public void OnExit()
    {
        animator.SetBool("isRunning", false);

    }

    public void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_direction.x * player.GetWalkingSpeed(), _rb.velocity.y);

        var scale = gameObject.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(_direction.x);
        gameObject.transform.localScale = scale;
    }


}
