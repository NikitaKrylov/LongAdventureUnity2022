using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : IState
{
    private Animator animator;
    private FSM weaponFSM;
    public IState handleInput(GameObject obj)
    {
        throw new System.NotImplementedException();
    }

    public void OnEnter(GameObject obj)
    {
        animator = obj.GetComponent<Animator>();
        weaponFSM = obj.GetComponent<Player>().WeaponFSM;

        animator.SetTrigger("SwordHit1");
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
