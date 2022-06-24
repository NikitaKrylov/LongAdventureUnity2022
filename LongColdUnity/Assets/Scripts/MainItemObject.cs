using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[ExecuteInEditMode]
public class MainItemObject: MonoBehaviour, IPointerClickHandler
{
    public AbstractItem objectModel;
    
    protected SpriteRenderer spriteRenderer;
    protected BoxCollider2D boxCollider;

    protected void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        spriteRenderer.sprite = objectModel.image;
        transform.localScale = objectModel.scale;
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        gameObject.name = objectModel.name;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) Take();

    }

    public void Take()
    {
        Inventory inv = Player.GetInstance().inventory;
        GameObject.FindGameObjectWithTag("Player")?.GetComponent<AnimationController>()?.PlayTakeAnimation();

        Item item = new Item(objectModel, 1, inv);
        Destroy(gameObject);
    }


}
