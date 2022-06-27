using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : IState
{
    private AnimationController animationController;
    private GameObject gameObject;

    public IState handleInput(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return new StandingState();
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        gameObject = obj;
        animationController = gameObject.GetComponent<AnimationController>();
        animationController.StartClimbingAnimation();
    }

    public void OnExit()
    {
        animationController.StopClimbingAnimation();
    }

    public void Update()
    {

    }
}
