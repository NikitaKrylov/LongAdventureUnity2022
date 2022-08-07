using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearWander : IState
{

    private Bear bear;
    private FSM fsm;
    private Vector2 direction;
    private float time = 0;
    private float targetTime = 0;
    private const float detectDistance = 5;

    public BearWander(FSM fsm)
    {
        this.fsm = fsm;
    }

    public IState handleInput(GameObject obj)
    {
        if (BearAggressive.DetectEnemy(bear.transform, detectDistance) != null) return new BearAggressive(fsm);

        else if (time >= targetTime)
        {
            if (Random.Range(0f, 1f) > .4)
            {
                direction.x *= -1;
                ChangeScaleByDirection(direction);
                time = 0;
                return null;
            }
            else return new BearIdle(fsm);
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        bear = obj.GetComponent<Bear>();
        bear.animator.SetBool("isWander", true);

        if (Random.value > .5f) direction = Vector2.right;
        else direction = Vector2.left;

        ChangeScaleByDirection(direction);

        targetTime = Random.Range(3.6f, 8);
        time = 0;
    }

    public void OnExit()
    {
        bear.animator.SetBool("isWander", false);

    }

    public void Update()
    {
        time += Time.deltaTime;
        Debug.Log($"{direction} {time} -> {targetTime}");
        bear.Move(new Vector2(bear.GetDefaultSpeed(), 0), direction);
    }

    private void ChangeScaleByDirection(Vector2 direction)
    {
        var scale = bear.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction.x);
        bear.transform.localScale = scale;
    }
}
