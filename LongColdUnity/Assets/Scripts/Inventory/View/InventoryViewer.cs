using System;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class InventoryViewer : MonoBehaviour, IDropHandler
{
    public Inventory inventory;

    [SerializeField] private Text inventoryWeight;
    public List<InventoryViewCell> viewItems = new List<InventoryViewCell>();
    [Tooltip("Объект ячейки с предметом")] public GameObject gameObjectShow;
    [Tooltip("Объект с компонентом сетки")] public GameObject InventoryMainObject;
    [Tooltip("Объект навигации для представления предметов")] public ItemStatNavigation itemStatNavigation;
    [Tooltip("Область перемещения (Canvas)"), SerializeField] private Transform _draggingCellParent;
    [Tooltip("Область родителя (Grid)"), SerializeField] private Transform _originCellParent;
    [SerializeField] private bool playerInventory = false;      

    public InventoryViewCell currentItem = null;
    private void Awake()
    {
        if (playerInventory) inventory = Player.GetInstance().inventory;
    }

    private void Update()
    {
        SetInventoryWeight();
    }

    public void SetInventoryWeight()
    {
        if (inventoryWeight != null) inventoryWeight.text = $"{inventory.GetWeight() / 1000} кг";
    }

    public void SetInventory(Inventory inv)
    {
        inventory = inv;
    }

    private InventoryViewCell UpdateAndGetItem(Item item)
    {
        InventoryViewCell viewItem = viewItems.Find(x => x.ii.currentItem.id == item.currentItem.id);
        viewItem?.UpdateCell();
        return viewItem ?? null;
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


    
    public void DeleteAllViewItem()
    {
        viewItems.ForEach(item => Destroy(item.gameObject));
        viewItems.Clear();
        
    }
  


    public void ShowItemRepresentation(InventoryViewCell item)
    {
        if (itemStatNavigation == null) return;

        UpdateCells();
        if ((item == null || item.isDragging) || (currentItem != null && item.ii == currentItem.ii))
        {
            itemStatNavigation?.Close();
            currentItem = null;
            return;
        }

        currentItem = item;
        itemStatNavigation.Show<InventoryViewCell>(currentItem);
    }

    public void UpdateCells()
    {
        DeleteAllViewItem();
        foreach (Item item in inventory.items)
        {
            AddViewItem(item);
        }
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
    public void FilterViewByCategory2(ItemCategory category)
    {

    }

    private void OnDisable()
    {
        DeleteAllViewItem();
        ShowItemRepresentation(null);
    }
    private void OnEnable()
    {
        DeleteAllViewItem();

        foreach (Item item in inventory.items) 
        {
            AddViewItem(item);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventoryViewCell cell = eventData.pointerDrag.gameObject.GetComponent<InventoryViewCell>();

        if (cell == null || cell.inventoryViewer == this) return;

        cell.inventoryViewer.inventory.RemoveItem(cell.ii);
        cell.inventoryViewer.UpdateCells();

        inventory.AddItem(cell.ii);
        UpdateCells();
    }
}


