using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Collections;

public class Creature : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float MaxXP;
     public float HP;

    [SerializeField] private List<DropItem> dropItems = new List<DropItem>();

    public float defaultSpeed = 2.2f;
    private Rigidbody2D rb;
    private FSM fsm;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        fsm = new FSM(gameObject, new RabbitWalkingState());
        HP = MaxXP;
    }

    private void Update()
    {
        fsm.Update();
    }

    public void Kill()
    {
        DropLoot();
        Destroy(gameObject);
    }
    public void Damage(float value)
    {
        Debug.Log(value);
        HP -= value;
        if (HP <= 0) Kill();
        else StartCoroutine(DamageAnimation());
    }
    private void DropLoot()
    {
       foreach (DropItem item in dropItems)
        {
            item.Drop(transform.position);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    private IEnumerator DamageAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = Color.white;

    }
}
