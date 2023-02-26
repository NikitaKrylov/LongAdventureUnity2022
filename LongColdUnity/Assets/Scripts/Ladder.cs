using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ladder : MonoBehaviour
{
    public float UpSpeed;
    public float DownSpeed;
    public bool hasRushDownSpeed = false;
    public float rushDownSpeed;

    private BoxCollider2D m_BoxCollider;
    private bool targetObjectInCollider;
    private Player targetObject;

    private void Start()
    {
        m_BoxCollider = GetComponent<BoxCollider2D>();
        m_BoxCollider.isTrigger = true;
    }


    private void Update()
    {
        if (targetObjectInCollider)
        {
            if (Mathf.Abs(Input.GetAxis("Vertical")) > .2)
            {

                if (targetObject.playerStateMachine.currentState is ClimbingState) return;

                targetObject.playerStateMachine.SetState(new ClimbingState(targetObject.playerStateMachine));
                ((ClimbingState)targetObject.playerStateMachine.currentState).SetLadderType(this);
            }
        }
    }

    private void SetClimbingState(StateMachine<Player> fsm)
    {
        if (fsm.currentState is ClimbingState) return;
        else
        {
            fsm.SetState(new ClimbingState(targetObject.playerStateMachine));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            targetObjectInCollider = true;
            targetObject = collision.gameObject.GetComponent<Player>();
        }
        else
        {
            targetObjectInCollider = false;
            targetObject = null;
        }
        


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (targetObjectInCollider)
            {
                if (targetObject.playerStateMachine.currentState is ClimbingState)
                {
                    targetObject.playerStateMachine.SetState(new StandingState(targetObject.playerStateMachine));
                }

            }

        }
        targetObjectInCollider = false;
        targetObject = null;

    }


}
