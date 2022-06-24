using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingState : IState
{
    private AnimationController animationController;
    private GameObject gameObject;

    public ShiftingState(GameObject obj)
    {
        OnEnter(obj);
    }

    public IState handleInput(GameObject obj)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            return new StandingState(obj);
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        gameObject = obj;
        animationController = gameObject.GetComponent<AnimationController>();
        animationController.StartShiftingAnimation();
    }

    public void OnExit()
    {
        animationController.StopShiftingAnimation();
    }

    public void Update()
    {
    }
}
