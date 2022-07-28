using UnityEngine;

public class WalkingState : IState
{
    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D _rb;
    private Animator animator;
    private GameObject gameObject;
    private FSM weaponFSM;
    private Player player;


    public IState handleInput(GameObject obj)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < .3) return new StandingState();

        else if (Mathf.Abs(Input.GetAxis("Horizontal")) > .3 && Input.GetKey(KeyCode.LeftControl)) return new RunningState();

        else if (Input.GetKey(KeyCode.LeftShift)) return new ShiftingState();

        else if (FallingState.isFalling(obj)) return new FallingState();


        return null;
    }

    public void OnEnter(GameObject obj)
    {
        gameObject = obj;
        player = gameObject.GetComponent<Player>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        weaponFSM = obj.GetComponent<Player>().WeaponFSM;
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
