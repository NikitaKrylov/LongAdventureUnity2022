using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftRecipeStatView : StatView
{
    public CraftSystem craftSystem;

    [SerializeField] protected new Text name;
    [SerializeField] protected Text description;
    [SerializeField] protected Image image;
    [SerializeField] protected Button button1;
    [SerializeField] protected Text necessaryItems;

    protected override void SetData<T>(T obj)
    {
        if (obj is CraftRecipe) SetRecipeItemData(obj as CraftRecipe);
        else throw new System.Exception("Method is not used with a type other than 'CraftRecipe'");
    }

    protected override void SetAbstractItemData(AbstractItem obj)
    {
        name.text = obj.name;
        description.text = obj.description;
        image.sprite = obj.image;
    }
    protected override void SetInventoryViewCellData(InventoryViewCell obj)
    {
        throw new System.Exception("Method is not implemented");
    }
    protected override void SetItemData(Item obj)
    {
        throw new System.Exception("Method is not implemented");
    }

    protected virtual void SetRecipeItemData(CraftRecipe obj)
    {
        SetAbstractItemData(obj.craftableItem);

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(delegate{

            PlayerInventory pI = PlayerInventory.GetInstance();
            Item item = obj.Craft(pI.items, 1);

            if (item != null)
            {
                pI.AddItem(item);
                craftSystem?.UpdateCraftRecipeItems();
            }
        });

        necessaryItems.text = "";
        for (int i = 0; i < obj.necessaryItems.Count; i++)
        {
            necessaryItems.text += $"{i+1}.{obj.necessaryItems[i].necessaryItem.name} x{obj.necessaryItems[i].neededAmount}   ";
        }

    }
}
