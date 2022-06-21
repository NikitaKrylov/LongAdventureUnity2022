using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;



public class Inventory : MonoBehaviour
{
    [SerializeField] public UnityEvent<Item> OnAddItem;
    [SerializeField] public UnityEvent<Item> OnRemoveItem;
    [SerializeField] public UnityEvent<Item> OnChangeItem;

    public List<Item> items = new List<Item>();
    public int Count { get { return items.Count; } }

    private void Start()
    {
        items.ForEach(item => OnAddItem.Invoke(item));
    }

    public float GetWeight()
    {
        float weight = 0f;

        foreach (Item item in items)
        {
            weight += item.count * item.currentItem.weight;
        }
        return weight;
    }

    public void AddItem(Item item)
    {
        if (HasItem(item))
        {
            Item currentItem = FindItemById(item.currentItem.GetInstanceID());
            currentItem.count += item.count;
            currentItem.Container = this;
            OnAddItem?.Invoke(currentItem);
            return;
        }
        item.Container = this;
        items.Add(item);
        OnAddItem?.Invoke(item);
    }

    


    public void PopItem(Item item)
    {
        bool rezult = items.Remove(item);
        if (rezult)
        {
            OnRemoveItem?.Invoke(item);
            CreateObject(item);
        }
    }

    public void PopItem(Item item, int amount)
    {
        Item rezult = FindItemById(item.currentItem.id);
        if (rezult != null)
        {
            if (rezult.count == amount)
            {
                items.Remove(item);
                OnRemoveItem?.Invoke(item);
                CreateObject(item);
            }
            else if (rezult.count > amount)
            {
                rezult.count -= amount;
                OnChangeItem?.Invoke(item);
                CreateObject(item, amount);
            }
        }
    }



    public void RemoveItem(Item item)
    {
        bool rezult = items.Remove(item);
        if (rezult)
        {
            OnRemoveItem?.Invoke(item);

        }
    }

    public void RemoveItem(Item item, int amount)
    {
        Item rezult = FindItemById(item.currentItem.id);
        if (rezult != null)
        {
            if (rezult.count > amount)
            {
                rezult.count -= amount;
                OnChangeItem?.Invoke(rezult);
            }
            else if (rezult.count == amount)
            {
                RemoveItem(rezult);
            }
        }
    }




    public bool HasItem(Item item)
    {
        return FindItemById(item.currentItem.id) != null;
    }

    public Item FindItemById(int id)
    {
        return items.Find(i => i.currentItem.id == id);
    }

    public void CreateObject(Item item, int? amount = null)
    {
        item.Container = null;
        for (int i = 0; i < (amount ?? item.count); i++)
        { 
            item.currentItem.CreateObject(new Vector3(
                transform.position.x,
                transform.position.y + GetComponent<CapsuleCollider2D>().size.y * 3,
                transform.position.z));
        }
    }

    

}


[Serializable]
public class Item
{
    public AbstractItem currentItem;
    public int count;
    public Inventory Container  = null;

    public Item(AbstractItem item, int count, Inventory container)
    {
        currentItem = item;
        this.count = count;
        Container = container;
        Container?.AddItem(this);
    }
    public void Remove(int amount)
    {
        Container?.RemoveItem(this, amount);
    }
    public void RemoveAll()
    {
        Container?.RemoveItem(this);
    }
    public void Pop(int amount)
    {
        Container?.PopItem(this, amount);
    }
    public void PopAll()
    {
        Container?.PopItem(this);
    }


}
