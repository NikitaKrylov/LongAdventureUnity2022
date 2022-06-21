using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CraftItemPanel : MonoBehaviour
{
    public CraftRecipe craftRecipe;

    [SerializeField] private Text _name;
    [SerializeField] private Image _image;
    [SerializeField] private Button button; 
    [SerializeField] private Color32 availableColor;
    [SerializeField] private Color32 unavailableColor;

    public void SetData(CraftRecipe recipe)
    {
        craftRecipe = recipe;
        SetImage(recipe.craftableItem.image);
        SetName(recipe.craftableItem.name);
    }

    public void SetImage(Sprite image)
    {
        _image.sprite = image;
    }
    public void SetName(string name)
    {
        _name.text = name;
    }
    public void SetPossibilityToCreate(bool value)
    {
        if (value)
        {
            _image.color = availableColor;
            _name.color = availableColor;
        }
        else
        {
            _image.color = unavailableColor;
            _name.color = unavailableColor;
        }

    }
    public void SetAction(UnityAction action)
    {
        button.onClick.AddListener(action);
    }



}
