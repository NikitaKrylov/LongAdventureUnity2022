using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : IState
{
    public static float fallingDistance = 3f;

    private const float fallingXSpeed = 1.2f;
    private GameObject gameObject;
    private Animator animator;
    private static Collider2D collider;

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
    public IState handleInput(GameObject obj)
    {
        if (!isFalling(obj))
        {
            return new StandingState();
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {

        gameObject = obj;
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
