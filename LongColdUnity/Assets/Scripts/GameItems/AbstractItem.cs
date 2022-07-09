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
    public new string name;
    public string description;
    public Sprite image;
    public Vector3 scale;
    public ItemCategory category;
    public GameObject prefab;
    public AudioClip dropSound;
    public AudioClip pickUpSound;
    public float weight;
    public bool craftable;
    public bool unique;


    public virtual GameObject CreateObject(Vector3 position, Vector3? rotation = null, Vector3? force = null)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = position;

        if (rotation.HasValue) obj.transform.rotation = Quaternion.Euler(rotation.Value);
        if (force.HasValue) obj.GetComponent<Rigidbody2D>().AddForce(force.Value);

        obj.GetComponent<MainItemObject>().objectModel = this;
        return obj;
    }
    public virtual Item CreateItem(int amount)
    {
        Item newItem = new Item(this, amount, null);
        return newItem; 
    }
}
