using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : PeacefulAnimal
{
    [SerializeField] private List<DropItem> dropItems = new List<DropItem>();
    private SpriteRenderer spriteRenderer;
    private const float damageAnimationDuration = .3f;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void DropLoot()
    {
        dropItems.ForEach(item => item.Drop(transform.position));
    }

    public override IState GetInitState()
    {
        return new RabbitIdle(fsm);
    }

    public override void Kill()
    {
        DropLoot();
        Destroy(gameObject, damageAnimationDuration);
    }

    public override IEnumerator TakeDamageAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(damageAnimationDuration);
        spriteRenderer.color = Color.white;
    }
}
