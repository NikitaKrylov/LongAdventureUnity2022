using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelPanel : MonoBehaviour
{
    public Item item;

    [SerializeField] private Image image;
    [SerializeField] private new Text name;
    [SerializeField] private Text value;

    public void SetData(Item item)
    {
        if (item.currentItem is not BurningMaterial) throw new System.Exception($"Объект '{item}.currentItem' должен быть типа 'BurningMaterial'");

        this.item = item;
        SetName(item.currentItem.name + " X" + item.count.ToString());
        SetImage(item.currentItem.image);
        SetValue("Fuel value: " + ((BurningMaterial)item.currentItem).fuelValue.ToString());
    }


    public void SetName(string text)
    {
        name.text = text;
    }
    public void SetImage(Sprite image)
    {
        this.image.sprite = image;
    }
    public void SetValue(string text)
    {
        value.text = text;
    }
}
