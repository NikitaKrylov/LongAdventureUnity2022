using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/CraftRecipe")]
public class CraftRecipe : ScriptableObject
{
    public AbstractItem craftableItem;
    public int exitAmount = 1;

    public List<CraftRecipeItem> necessaryItems = new List<CraftRecipeItem>();
    public List<AbstractItem> requiredTools = new List<AbstractItem>(); 
    public string Name { get { return craftableItem.name; } }
    public Sprite Image { get { return craftableItem.image;} }
    public AbstractItem CraftableItem { get { return craftableItem; } }

    public Item Craft(List<Item> sourceItems, int amount, List<Item> requiredTools = null)
    {
        if (!Validate(sourceItems)) return null;

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
            var rez1 = sourceItems.Find(x => x.currentItem == item.necessaryItem && x.count >= item.neededAmount);
            if (rez1 == null) return false;
        }
        foreach (AbstractItem tool in requiredTools)
        {
            var rez2 = sourceItems.Find(y => y.currentItem == tool);
            if (rez2 == null) return false;
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
