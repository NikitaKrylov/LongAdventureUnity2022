using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Creature, ILivable, IDroppable
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public Animator animator;

    private StateMachine<Rabbit> stateMachine;
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


    protected override void Start()
    {
        base.Start();
        stateMachine = new StateMachine<Rabbit>(this, new RabbitIdleState(stateMachine));
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        stateMachine.Update();
    }
    public void Damage(float value)
    {
        if (Health - value <= 0) Kill();
        else Health -= value;
    }

    public void Kill()
    {
        Destroy(gameObject);
        Drop();
    }

    public void Drop()
    {
        throw new System.NotImplementedException();
    }
}
