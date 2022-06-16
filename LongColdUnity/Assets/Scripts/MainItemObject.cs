using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[ExecuteInEditMode]
public class MainItemObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AbstractItem objectModel;
    
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        Init();
    }

    public void Init()
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
        Take();
    }

    public void Take()
    {
        PlayerInventory inv = PlayerInventory.GetInstance();
        GameObject.FindGameObjectWithTag("Player")?.GetComponent<AnimationController>()?.PlayTakeAnimation();

        Item item = new Item(objectModel, 1, inv);
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
