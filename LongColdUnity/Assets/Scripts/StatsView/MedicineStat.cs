using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicineStat : BaseItemStatView
{
    [SerializeField] Text recoveringValue;
    [SerializeField] Button button2;

    protected override void SetAbstractItemData(AbstractItem obj)
    {
        base.SetAbstractItemData(obj);

        if (obj is Medicine)
        {
            recoveringValue.text = ((Medicine)obj).recoveringValue.ToString();
        }
    }

    protected override void SetItemData(Item obj)
    {
        base.SetItemData(obj);

        button2.onClick.AddListener(delegate {
            ((Medicine)(obj.currentItem)).Use();
            obj.Remove(1);
            if (obj.count == 0) Close();
        });
    }

    protected override void SetInventoryViewCellData(InventoryViewCell obj)
    {
        base.SetInventoryViewCellData(obj);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(delegate { obj.inventoryViewer.UpdateCells(); });
        SetItemData(obj.ii);
    }
}
