using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : IState<Player>
{
    public ClimbingState(StateMachine<Player> fsm)
    {
        this.fsm = fsm;
    }

    private StateMachine<Player> fsm;
    private GameObject gameObject;
    private Animator animator;
    private Rigidbody2D rb;
    private Ladder ladder;

    public IState<Player> handleInput(Player player)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return new StandingState(fsm);
        }
        return null;
    }

    public void OnEnter(Player player)
    {
        gameObject = player.gameObject;
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        animator.SetBool("isClimbing", true);
        rb.gravityScale = 0;
    }

    public void OnExit()
    {
        animator.SetBool("isClimbing", false);
        rb.gravityScale = 1;

    }

    public void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        gameObject.transform.Translate(direction * ladder.UpSpeed * Time.deltaTime);
    }

    public void SetLadderType(Ladder ld)
    {
        ladder = ld;
    }
}
