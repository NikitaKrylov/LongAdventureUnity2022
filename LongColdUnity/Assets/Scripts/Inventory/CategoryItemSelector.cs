using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryItemSelector : MonoBehaviour
{
    [SerializeField] public List<Button> categoryButtons = new List<Button>();
    [SerializeField] private InventoryViewer inventoryViewer;

    private void Start()
    {
        categoryButtons.ForEach(button => button.onClick.AddListener(delegate { SelectCategory(button); }));
    }

    private void SelectCategory(Button button)
    {
        inventoryViewer.FilterViewByCategory(button.name);
    }
}
