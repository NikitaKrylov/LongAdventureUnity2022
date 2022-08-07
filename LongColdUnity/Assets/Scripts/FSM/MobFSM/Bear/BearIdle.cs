using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearIdle : IState
{
    private FSM fsm;
    private Bear bear;
    private float time = 0;
    private float targetTime = 0;
    private const float detectDistance = 5;

    public BearIdle(FSM fsm)
    {
        this.fsm = fsm; 
    }
    public IState handleInput(GameObject obj)
    {
        if (BearAggressive.DetectEnemy(bear.transform, detectDistance) != null) return new BearAggressive(fsm);

        else if (time >= targetTime) return new BearWander(fsm);
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        bear = obj.GetComponent<Bear>();
        targetTime = Random.Range(2.6f, 6);
    }

    public void OnExit()
    {
        
    }

    public void Update()
    {
        time += Time.deltaTime;
    }
}
