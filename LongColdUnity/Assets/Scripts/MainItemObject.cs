using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[ExecuteInEditMode]
public class MainItemObject: MonoBehaviour, IPointerClickHandler,  IPointerExitHandler
{
    public AbstractItem objectModel;
    protected Item itemObject;
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


    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Take();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (objectModel is Food)
            {
                ((Food)objectModel).Use();
                Destroy(gameObject);
            }
            else if (objectModel is Medicine)
            {
                ((Medicine)objectModel).Use();
                Destroy(gameObject);
            }
            else if (objectModel is Weapon)
            {
                Player.GetInstance().EquipmentSet.SetWeapon((Weapon)objectModel);
                Take();
            }
        }

    }

    public void Take()
    {
        Inventory inv = Player.GetInstance().inventory;
        GameObject.FindGameObjectWithTag("Player")?.GetComponent<Animator>().SetTrigger("Take");

        Item item = new Item(objectModel, 1, inv);
        Tooltip.Hide();
        Destroy(gameObject);
    }


    private void OnMouseOver()
    {
        string text = "";

        if (objectModel is Food) text = "Eat";
        else if (objectModel is Medicine) text = "Use";
        else if (objectModel is Weapon) text = "Equip";

        Tooltip.Show(objectModel.name, "Take", text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Hide();
    }
}
