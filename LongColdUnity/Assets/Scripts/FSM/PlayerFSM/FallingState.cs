using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : IState
{

    private AnimationController animationController;
    private GameObject gameObject;
    private static Collider2D collider;
    public static float fallingDistance = 3f;

    public FallingState(GameObject obj)
    {
        OnEnter(obj);
    }

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
            return new StandingState(obj);
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {

        gameObject = obj;
        animationController = gameObject.GetComponent<AnimationController>();
        animationController.StartFallingAnimation();
    }

    public void OnExit()
    {
        animationController.StopFallingAnimation();

    }

    public void Update()
    {
    }
}
