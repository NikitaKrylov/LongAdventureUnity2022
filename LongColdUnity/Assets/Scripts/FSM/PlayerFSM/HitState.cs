using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : IState
{
    private ComboSystem comboSystem;
    private FSM weaponFSM;
    public IState handleInput(GameObject obj)
    {
        if (!comboSystem.isActive)
        {
            return new StandingState();
        }
        return null;
    }

    public void OnEnter(GameObject obj)
    {
        weaponFSM = obj.GetComponent<Player>().WeaponFSM;
        comboSystem = obj.GetComponent<ComboSystem>();
        comboSystem.Play();
    }

    public void OnExit()
    {
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            comboSystem.Play();
        }
    }
}
