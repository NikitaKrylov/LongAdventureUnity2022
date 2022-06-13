using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerViewer : InventoryViewer
{
    public Container container = null;
    private DropHeandler _dropHeandler;


    private void Awake()
    {
        _dropHeandler = GetComponent<DropHeandler>();   
    }
    private void OnDisable()
    {
        DeleteAllViewItem();
        try
        {
            _dropHeandler.OnDropEvent.RemoveListener(container.AddItem);
        }
        catch{}
        
        container = null;
    }


    private void OnEnable()
    {
        DeleteAllViewItem();
    }

    //Колхозный метод
    //представление дублирует логику объекта Container
    public void RemoveItemFromContainer(Item item)
    {
        if (container != null)
        {
            container.RemoveItem(item);
        }
    }


    public void SetViewItems(List<Item> items)
    {
        

        foreach (Item item in items)
        {
            AddViewItem(item);
        }
    }
    public void Show(Container container)
    {
        this.container = container;
        SetViewItems(container.items);
        _dropHeandler.OnDropEvent.AddListener(this.container.AddItem);

    }
}
