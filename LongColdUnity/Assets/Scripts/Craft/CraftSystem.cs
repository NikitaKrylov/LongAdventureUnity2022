using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    [SerializeField] private GameObject craftViewList;
    [SerializeField] private CraftRecipeStatView craftRecipeStatView;
    [SerializeField] private GameObject recipeItem;
    private List<CraftItemPanel> _craftItemPanels = new List<CraftItemPanel>();

    [SerializeField] private List<CraftRecipe> CraftRecipies = new List<CraftRecipe>();


    private void Start()
    {
        craftRecipeStatView.craftSystem = this;
        CreateCraftRecipeItems(CraftRecipies);
        UpdateCraftRecipeItems();
    }



    public void AddCraftRecipe(CraftRecipe recipe)
    {
        if (CraftRecipies.Contains(recipe)) return;
        CraftRecipies.Add(recipe);
    }

    private void CreateCraftRecipeItems(List<CraftRecipe> craftRecipies)
    {
        for (int i = 0; i < craftRecipies.Count; i++)
        {
            CraftRecipe craftRecipe = craftRecipies[i];
            //Craft(craftRecipe);
            GameObject recipeObject = Instantiate(recipeItem, craftViewList.transform);
            recipeObject.GetComponentInChildren<Button>().onClick.AddListener(delegate{
                if (craftRecipeStatView.IsActive) craftRecipeStatView.Close();
                else craftRecipeStatView.Show(craftRecipe);
            });
            CraftItemPanel craftItemPanel = recipeObject.GetComponent<CraftItemPanel>();

            craftItemPanel.craftRecipe = craftRecipe;
            craftItemPanel.SetName(craftRecipe.Name);
            craftItemPanel.SetImage(craftRecipe.Image);
            _craftItemPanels.Add(craftItemPanel);
        }
    }

    
    public void UpdateCraftRecipeItems()
    {
        foreach (CraftItemPanel panel in _craftItemPanels)
        {
            var playerInv = PlayerInventory.GetInstance();
            panel.SetPossibilityToCreate(panel.craftRecipe.Validate(playerInv.items));
        }
    }

    public void Craft(CraftRecipe recipe)
    {
        Inventory inventory = PlayerInventory.GetInstance();

        if (!recipe.Validate(inventory.items)) 
        {
            Debug.Log("Dont have items for craft");
            return;
        }

        Item newItem = recipe.Craft(inventory.items, 1);

        inventory.AddItem(newItem);
    }

    private void OnEnable()
    {
        UpdateCraftRecipeItems();
    }

}
