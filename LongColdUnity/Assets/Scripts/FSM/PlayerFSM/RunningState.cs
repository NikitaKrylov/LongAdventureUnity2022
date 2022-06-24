using UnityEngine;

public class RunningState : IState
{
    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D _rb;
    private AnimationController animationController;
    private GameObject gameObject;
    public static float speed = 5f;

    public RunningState(GameObject obj)
    {
        OnEnter(obj);
    }

    public IState handleInput(GameObject obj)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < .3)
        {
            return new StandingState(obj);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            return new ShiftingState(obj);
        }
        else if (FallingState.isFalling(obj))
        {
            return new FallingState(obj);
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        gameObject = obj;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        animationController = gameObject.GetComponent<AnimationController>();

        animationController.StartRunAnimation();
    }

    public void OnExit()
    {
        animationController.StopRunAnimation();
    }

    public void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_direction.x * speed, _rb.velocity.y);
        animationController.Flip(new Vector3(Mathf.Sign(_direction.x), 1, 1));
    }


}
