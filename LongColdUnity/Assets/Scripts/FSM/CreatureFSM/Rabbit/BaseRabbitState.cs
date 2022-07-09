using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRabbitState : CreatureState
{

    protected float time = 0;
    protected float thresholdTime;
    protected const float detectRadius = 2.5f;
    protected const float maxDetectRadius = 8f;

    public override float GetRandomTime()
    {
        return Random.Range(3, 8);
    }


    public override void Update()
    {
        time += Time.deltaTime;
    }

    
    
}
