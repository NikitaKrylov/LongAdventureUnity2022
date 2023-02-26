using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : IState<Player>
{
    public FallingState(StateMachine<Player> fsm)
    {
        this.fsm = fsm;
    }

    private StateMachine<Player> fsm;
    private const float fallingXSpeed = 1.2f;
    private GameObject gameObject;
    private Animator animator;
    private static Collider2D collider;

    public static float fallingDistance = 3f;

    public static bool isFalling(GameObject obj)
    {
        if (collider == null) collider = obj.GetComponent<Collider2D>();

        RaycastHit2D[] hits =  Physics2D.RaycastAll(collider.bounds.center, Vector2.down, fallingDistance);

        Debug.DrawLine(collider.bounds.center, collider.bounds.center + Vector3.down * fallingDistance);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.gameObject.CompareTag("Ground"))
            {
                return false;
            }
        }

        return true;
    }
    public IState<Player> handleInput(Player player)
    {
        if (!isFalling(player.gameObject))
        {
            return new StandingState(fsm);
        }
        return null;
    }

    public void OnEnter(Player player)
    {

        gameObject = player.gameObject;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isFalling", true);
    }

    public void OnExit()
    {
        animator.SetBool("isFalling", false);

    }

    public void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(directionX * fallingXSpeed * Time.deltaTime, 0, 0);
    }
}
