using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatNavigation : MonoBehaviour
{
    [SerializeField] private BaseItemStatView baseItemStatView;
    [SerializeField] private MedicineStat medicineStatView;
    [SerializeField] private FoodStat foodStatView;
    [SerializeField] private WeaponStat weaponStatView;

    private UIAggregator aggregator;
     
    public StatView currentStat = null;

    private void Start()
    {
        aggregator = GetComponent<AggregationComponent>().aggregator;
    }

    public void Show<T>(T obj)
    {
        currentStat?.Close();
        currentStat = Navigate<T>(obj);
        aggregator.Show(GetComponent<AggregationComponent>());

    }
    public void Close()
    {
        currentStat?.Close();
        aggregator?.Close(GetComponent<AggregationComponent>());

    }

    private StatView Navigate<T>(T obj)
    {
        ItemCategory category = ItemCategory.Material;

        if (obj is Item item) category = item.currentItem.category;
        else if (obj is InventoryViewCell inventoryViewCell) category = inventoryViewCell.ii.currentItem.category;
        else if (obj is AbstractItem absItem) category = absItem.category;

        switch (category)
        {
            case ItemCategory.Medicine:
                medicineStatView.Show<T>(obj);
                return medicineStatView;

            case ItemCategory.Food:
                foodStatView.Show<T>(obj);
                return foodStatView;
            case ItemCategory.Weapon:
                weaponStatView.Show<T>(obj);
                return weaponStatView;

            default:
                baseItemStatView.Show<T>(obj);
                return baseItemStatView;
        }   
        
    }
}
