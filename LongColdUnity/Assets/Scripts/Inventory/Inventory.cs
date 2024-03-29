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
            return;
        }
        item.Container = this;
        items.Add(item);
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
                CreateObject(item);
            }
            else if (rezult.count > amount)
            {
                rezult.count -= amount;
                CreateObject(item, amount);
            }
        }
    }



    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void RemoveItem(Item item, int amount)
    {
        Item rezult = FindItemById(item.currentItem.id);
        if (rezult != null)
        {
            if (rezult.count > amount)
            {
                rezult.count -= amount;
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
            item.currentItem.CreateObject(
                item
                ,new Vector3(
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
    private float durabilityStep = 1;

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
    public void ChangeDurability(float mulVal = 1)
    {
        durabilityPoints += durabilityStep * mulVal;
    }


}
