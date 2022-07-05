using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;



public class Inventory
{
   
    public List<Item> items = new List<Item>();
    public int Count { get { return items.Count; } }
    public float maxContentWeight;

    private void Start()
    {
        //items.ForEach(item => OnAddItem.Invoke(item));
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
            //OnAddItem?.Invoke(currentItem);
            return;
        }
        item.Container = this;
        items.Add(item);
        //OnAddItem?.Invoke(item);
    }

    public void AddItems(List<Item> items)
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }


    public void PopItem(Item item)
    {
        bool rezult = items.Remove(item);
        if (rezult)
        {
            //OnRemoveItem?.Invoke(item);
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
                //OnRemoveItem?.Invoke(item);
                CreateObject(item);
            }
            else if (rezult.count > amount)
            {
                rezult.count -= amount;
                //OnChangeItem?.Invoke(item);
                CreateObject(item, amount);
            }
        }
    }



    public void RemoveItem(Item item)
    {
        bool rezult = items.Remove(item);
        if (rezult)
        {
            //OnRemoveItem?.Invoke(item);

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
                //OnChangeItem?.Invoke(rezult);
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
        Player player = Player.GetInstance();
        item.Container = null;
        for (int i = 0; i < (amount ?? item.count); i++)
        { 
            item.currentItem.CreateObject(new Vector3(
                player.transform.position.x,
                player.transform.position.y + player.GetComponent<CapsuleCollider2D>().size.y * 3,
                player.transform.position.z));
        }
    }

    

}


[Serializable]
public class Item
{
    public AbstractItem currentItem;
    public int count;
    public Inventory Container  = null;
    public readonly bool hasDurabilityPoints;
    public float durabilityPoints { get; private set; }

    public Item(AbstractItem item, int count, Inventory container, bool hasDurabilityPoints = false, float durabilityPoints = 0)
    {
        currentItem = item;
        this.count = count;

        if (hasDurabilityPoints)
        {
            this.hasDurabilityPoints = hasDurabilityPoints;
            this.durabilityPoints = durabilityPoints;   
        }
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
