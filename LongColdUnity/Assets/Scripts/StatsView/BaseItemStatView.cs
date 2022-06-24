using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseItemStatView : StatView
{
    [SerializeField] protected new Text name;
    [SerializeField] protected Text description;
    [SerializeField] protected Text count;
    [SerializeField] protected Text weight;
    [SerializeField] protected Image image;
    [SerializeField] protected Button button1;

    protected override void SetAbstractItemData(AbstractItem obj)
    {
        name.text = obj.name;
        description.text = obj.description;
        image.sprite = obj.image;
    }

    protected override void SetInventoryViewCellData(InventoryViewCell obj)
    {
        button1.onClick.RemoveAllListeners();
        SetItemData(obj.ii);
        button1.onClick.AddListener(delegate {
            obj.inventoryViewer.UpdateCells();
        });

    }

    protected override void SetItemData(Item obj)
    {
        count.text = obj.count.ToString();
        weight.text = $"{obj.count * obj.currentItem.weight / 1000} Í„";
        button1.onClick.AddListener(delegate { 
            obj.PopAll();
            Close();
        } );

        SetAbstractItemData(obj.currentItem);
    }
}
