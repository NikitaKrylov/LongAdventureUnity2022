using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureState : IState
{
    private Creature creature;
    private float time = 0;
    private float thresholdTime;

    public abstract IState handleInput(GameObject obj);

    public void OnEnter(GameObject obj)
    {
        thresholdTime = GetRandomTime();
        creature = obj.GetComponent<Creature>();
    }

    public abstract void OnExit();

    public void Update()
    {
        time += Time.deltaTime;
    }

    public abstract float GetRandomTime();
}
