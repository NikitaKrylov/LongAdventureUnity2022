using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class Creature : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float MaxXP;
     public float HP;

    [SerializeField] private List<DropItem> dropItems = new List<DropItem>();
    [SerializeField] private GameObject floatingTextPrefab;

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
        StartCoroutine(DamageAnimation());
        HP -= value;
        if (HP <= 0) 
        {
            Kill();
        } 
        else 
        {
            ShowFloatingText(value.ToString(), transform.parent);
        }
        
    }

    private void ShowFloatingText(string text, Transform tr)
    {
        var ft = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, tr);
        TextMeshPro textMesh = ft.GetComponent<TextMeshPro>();
        textMesh.text = text;
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
