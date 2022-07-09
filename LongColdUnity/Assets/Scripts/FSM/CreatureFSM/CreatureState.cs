using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureState : IState
{
    protected Creature creature;


    public abstract IState handleInput(GameObject obj);

    public virtual void OnEnter(GameObject obj)
    {
        creature = obj.GetComponent<Creature>();
    }

    public abstract void OnExit();


    public abstract float GetRandomTime();

    public abstract void Update();

    protected GameObject DetectPlayer(float detectedRadius)
    {
        RaycastHit2D[] rayCasts = Physics2D.CircleCastAll(creature.transform.position, detectedRadius, Vector2.up);

        foreach (RaycastHit2D raycastHit in rayCasts)
        {
            if (raycastHit.transform.CompareTag("Player")) return raycastHit.transform.gameObject;
        }

        return null;
    }
}
