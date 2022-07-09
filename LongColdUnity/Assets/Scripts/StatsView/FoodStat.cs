using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodStat : BaseItemStatView
{
    [SerializeField] Text foodValue;
    [SerializeField] Text waterValue;
    [SerializeField] Button button2;

    protected override void SetAbstractItemData(AbstractItem obj)
    {
        base.SetAbstractItemData(obj);

        if (obj is Food)
        {
            if (obj is Water)
            {
                waterValue.text = ((Water)obj).waterValue.ToString();
                foodValue.text = "-";
            }
            else if (obj is SolidFood) 
            {
                foodValue.text = ((SolidFood)obj).foodValue.ToString();
                waterValue.text = "-";
            }
            else if (obj is ComboFood)
            {
                waterValue.text = ((ComboFood)obj).waterValue.ToString();
                foodValue.text = ((ComboFood)obj).foodValue.ToString();
            }
        }
    }

    protected override void SetItemData(Item obj)
    {
        base.SetItemData(obj);

        button2.onClick.AddListener(delegate {
            ((Food)(obj.currentItem)).Use();
            if (obj.count - 1 == 0)
            {
                obj.Remove(1);
                Close();
            }
            else
            {
                obj.Remove(1);
            }
        });
    }

    protected override void SetInventoryViewCellData(InventoryViewCell obj)
    {
        base.SetInventoryViewCellData(obj);

        button2.onClick.RemoveAllListeners();
        SetItemData(obj.ii);
        button2.onClick.AddListener(delegate { obj.inventoryViewer.UpdateCells(); });
    }
}
