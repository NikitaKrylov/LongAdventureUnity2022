using UnityEngine;

public class SleepingState : IState
{
    private bool canSkip = true;
    private GameObject gameObject;
    private AnimationController animationController;

    public SleepingState(GameObject obj)
    {
        OnEnter(obj);
    }
    public IState handleInput(GameObject obj)
    {
        if (!canSkip) return null;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.U))
        {
            return new StandingState(obj);
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        gameObject = obj;
        animationController = gameObject.GetComponent<AnimationController>();

        animationController.PlaySleepingAnimation();
    }
    public void OnExit()
    {
        animationController.StopSleepingAnimation();
        Debug.Log("dont sleep");
    }
    public void Update(){}
}
