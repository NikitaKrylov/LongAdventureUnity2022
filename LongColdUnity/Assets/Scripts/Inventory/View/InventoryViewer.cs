using System;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class InventoryViewer : MonoBehaviour
{
    [SerializeField] private Text inventoryWeight;

    public List<InventoryViewCell> viewItems = new List<InventoryViewCell>();
    [Tooltip("Объект ячейки с предметом")] public GameObject gameObjectShow;
    [Tooltip("Объект с компонентом сетки")] public GameObject InventoryMainObject;
    [Tooltip("Объект навигации для представления предметов")] public ItemStatNavigation itemStatNavigation;
    [Tooltip("Область перемещения (Canvas)"), SerializeField] private Transform _draggingCellParent;
    [Tooltip("Область родителя (Grid)"), SerializeField] private Transform _originCellParent;

    public InventoryViewCell currentItem = null;

    private void Update()
    {
        SetInventoryWeight();
    }

    public void SetInventoryWeight()
    {
        inventoryWeight.text = $"{PlayerInventory.GetInstance().GetWeight() / 1000} кг";
    }

    public void UpdateInventory()
    {
        foreach (InventoryViewCell cell in viewItems)
        {
            cell.UpdateCell();
        }
    }

    private InventoryViewCell UpdateAndGetItem(Item item)
    {
        InventoryViewCell viewItem = viewItems.Find(x => x.ii.currentItem.id == item.currentItem.id);
        viewItem?.UpdateCell();
        return viewItem ?? null;
    }



    public void UpdateItem(InventoryViewCell viewItem)
    {
        viewItem.UpdateCell();
    }

    public void AddViewItem( Item item)
    {
        InventoryViewCell result = UpdateAndGetItem(item);
        if (result != null) { return; }

        GameObject newItem = Instantiate(gameObjectShow, InventoryMainObject.transform);
        InventoryViewCell ivc = newItem.GetComponent<InventoryViewCell>();

        ivc.inventoryViewer = this;
        ivc.ii = item;
        ivc.OnClickAction += ShowItemRepresentation;
        ivc._draggingParent = _draggingCellParent;
        ivc._originParent = _originCellParent;

        newItem.name = item.currentItem.name;
        RectTransform rt = newItem.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0, 0, 0);
        rt.localScale = new Vector3(1, 1, 1);
        newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
        
        viewItems.Add(ivc);

    }

    public void UpdateViewItem(Item item)
    {
        InventoryViewCell viewItem = viewItems.Find(x => x.ii.currentItem.id == item.currentItem.id);
        viewItem?.UpdateCell();

    }

    public void PopViewItem(Item item) 
    {
        for (int i = 0; i < viewItems.Count; i++)
        {
            if (viewItems[i].ii == item)
            {
                Destroy(viewItems[i].gameObject);
                viewItems.RemoveAt(i);
                UpdateInventory();
                ShowItemRepresentation(null);
                break; 
            }
        }
    }
    public void DeleteAllViewItem()
    {
        viewItems.ForEach(item => Destroy(item.gameObject));
        viewItems.Clear();
        
    }
  


    public void ShowItemRepresentation(InventoryViewCell item)
    {
        if (itemStatNavigation == null) return;

        UpdateInventory();
        if ((item == null || item.isDragging) || (currentItem != null && item.ii == currentItem.ii))
        {
            itemStatNavigation?.Close();
            currentItem = null;
            return;
        }

        currentItem = item;
        itemStatNavigation.Show<InventoryViewCell>(currentItem);
    }

    public void SetAllActive(bool value)
    {
        viewItems.ForEach(item => item.gameObject.SetActive(value));
    }
    public void FilterViewByCategory(string category)
    {
        SetAllActive(true);

        if (category == "All") { return;}

        for (int i = 0; i < viewItems.Count; i++)
        {
            var item = viewItems[i];
            if (item.ii.currentItem.category.ToString() != category)
            {
                item.gameObject.SetActive(false);
            }
        }    
    }

    private void OnDisable()
    {
        ShowItemRepresentation(null);
    }
    private void OnEnable()
    {
        UpdateInventory();
    }


}


