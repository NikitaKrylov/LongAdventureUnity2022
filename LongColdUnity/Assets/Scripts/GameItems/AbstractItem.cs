using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory
{
    Food,
    Weapon,
    Material,
    Medicine,
    Equipment
}

public abstract class AbstractItem : ScriptableObject
{
    
    public int id => GetInstanceID();

    [Header("Item properties")]
    public new string name;
    public string description;
    public ItemCategory category;
    public float weight;
    public bool craftable;
    public bool unique;

    [Space]

    [Header("GameObject properties")]
    public Sprite image;
    public Vector3 scale;
    public GameObject prefab;

    [Space]

    [Header("Audio")]
    public AudioClip dropSound;
    public AudioClip pickUpSound;


    public virtual GameObject CreateObject(Item existedItem ,Vector3 position, Vector3? rotation = null, Vector3? force = null)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = position;

        if (rotation.HasValue) obj.transform.rotation = Quaternion.Euler(rotation.Value);
        if (force.HasValue) obj.GetComponent<Rigidbody2D>().AddForce(force.Value);

        MainItemObject mio = obj.GetComponent<MainItemObject>();

        mio.objectModel = this;
        if (existedItem != null) mio.itemObject = existedItem;
        else mio.itemObject = this.CreateItem(1);

        return obj;
    }
    public virtual Item CreateItem(int amount)
    {
        Item newItem = new Item(this, amount, null);
        return newItem; 
    }
}
