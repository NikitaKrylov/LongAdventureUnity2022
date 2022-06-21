using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
            GameObject recipeObject = Instantiate(recipeItem, craftViewList.transform);
            CraftItemPanel craftItemPanel = recipeObject.GetComponent<CraftItemPanel>();

            recipeObject.GetComponentInChildren<Button>().onClick.AddListener(delegate{
                craftRecipeStatView.Show(craftRecipe);
                //if (craftRecipeStatView.IsActive) craftRecipeStatView.Close();
                //else craftRecipeStatView.Show(craftRecipe);
            });
            craftItemPanel.SetData(craftRecipe);
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
