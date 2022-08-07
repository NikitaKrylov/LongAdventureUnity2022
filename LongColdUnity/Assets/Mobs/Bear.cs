using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bear : EnemyAnimal
{
    [SerializeField] private List<DropItem> dropItems = new List<DropItem>();
    [SerializeField] private Transform damageTransformPoint;
    [SerializeField] private float damageRadius;
    private const float damageAnimationDuration = .3f;
    private SpriteRenderer spriteRenderer;
    public override float triggerDistance => throw new System.NotImplementedException();

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Damage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(damageTransformPoint.position, damageRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.transform.gameObject != gameObject && collider.transform.gameObject.GetComponent<IMob>() != null )
            {
                collider.transform.gameObject.GetComponent<IMob>().TakeDamage(damage);
            }
            else if (collider.transform.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player");
                collider.transform.gameObject.GetComponent<Player>().TakeDamage(damage);
            }
        }
    }
    public override void TakeDamage(float value)
    {
        base.TakeDamage(value);
        
        // Switch to aggresive state
    }

    public override void DropLoot() => dropItems.ForEach(item => item.Drop(transform.position));
    public override IState GetInitState() => new BearWander(fsm);

    public override void Kill()
    {
        Destroy(gameObject);
        DropLoot();
    }

    public override IEnumerator TakeDamageAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(damageAnimationDuration);
        spriteRenderer.color = Color.white;
    }


}
