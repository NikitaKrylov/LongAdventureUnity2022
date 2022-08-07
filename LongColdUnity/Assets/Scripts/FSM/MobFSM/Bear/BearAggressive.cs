using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAggressive : IState
{
    private Bear bear;
    private FSM fsm;
    private Vector2 direction;
    private const float detectDistance = 8;
    private float maxDamageDistance = 2;
    private bool switchBack = false;

    public BearAggressive(FSM fsm)
    {
        this.fsm = fsm;
    }
    public IState handleInput(GameObject obj)
    {
        if (switchBack) return new BearWander(fsm);

        return null;
    }

    public void OnEnter(GameObject obj)
    {
        bear = obj.GetComponent<Bear>();
        bear.animator.SetBool("isWander", true);
    }

    public void OnExit()
    {
        bear.animator.SetBool("isWander", false);

    }

    public void Update()
    {
        GameObject go = DetectEnemy(bear.transform, detectDistance);
        if (go == null)
        {
            switchBack = true;
            return;
        }

        direction.x = Mathf.Sign(go.transform.position.x - bear.transform.position.x);
        ChangeScaleByDirection(direction);

        if (Vector2.Distance(go.transform.position, bear.transform.position) <= maxDamageDistance)
        {
            bear.animator.SetTrigger("hit");
        }
        else
        {
            bear.Move(new Vector2(bear.GetMaxSpeed(), 0), direction);

        }

    }
    public static GameObject DetectEnemy(Transform transform, float distance)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, distance, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.gameObject.CompareTag("Player")) return hit.transform.gameObject;
        }
        return null;    
    }
    private void ChangeScaleByDirection(Vector2 direction)
    {
        var scale = bear.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction.x);
        bear.transform.localScale = scale;
    }
}
