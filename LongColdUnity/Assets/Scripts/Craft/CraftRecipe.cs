using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/CraftRecipe")]
public class CraftRecipe : ScriptableObject
{
    public AbstractItem craftableItem;

    public List<CraftRecipeItem> necessaryItems = new List<CraftRecipeItem>();
    public string Name { get { return craftableItem.name; } }
    public Sprite Image { get { return craftableItem.image;} }
    public AbstractItem CraftableItem { get { return craftableItem; } }

    public Item Craft(List<Item> sourceItems, int amount)
    {
        if (!Validate(sourceItems)) return null;

        //Корявый код
        foreach (CraftRecipeItem recipeItem in necessaryItems)
        {
            Item rez = sourceItems.Find(x => x.currentItem == recipeItem.necessaryItem);
            rez.Remove(recipeItem.neededAmount);
        }
        Item creationItem = craftableItem.CreateItem(amount);
        return creationItem;
    }

    public bool Validate(List<Item> sourceItems)
    {
        foreach (CraftRecipeItem item in necessaryItems)
        {
            var rez = sourceItems.Find(x => x.currentItem == item.necessaryItem && x.count >= item.neededAmount);
            if (rez == null) return false;  
        }
        return true;
    }

    [System.Serializable]
    public class CraftRecipeItem
    {
        public AbstractItem necessaryItem;
        public int neededAmount;
    }

}
