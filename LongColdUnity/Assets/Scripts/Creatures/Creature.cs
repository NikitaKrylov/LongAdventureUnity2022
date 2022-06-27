using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;


public class Creature : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float MaxXP;
     public float HP;

    [SerializeField] private List<DropItem> dropItems = new List<DropItem>();

    public float defaultSpeed = 2.2f;
    private Rigidbody2D rb;
    private FSM fsm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fsm = new FSM(gameObject, new RabbitRunningState());
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
        HP -= value;
        if (HP <= 0) Kill();
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
}
