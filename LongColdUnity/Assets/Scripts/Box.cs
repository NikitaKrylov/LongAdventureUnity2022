using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private new string name = "Контейнер";
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private float maxContentWeight;

    private Inventory inventory;
    private AudioSource openSound;

    private void Start()
    {
        openSound = GetComponent<AudioSource>();
        inventory = new Inventory();
        inventory.AddItems(items);
    }

    public void Open()
    {
        openSound.Play();

        UIManager uiManager = UIManager.Instance;
        uiManager.inventoryComponent.Show();

        InventoryViewer invV = uiManager.containerViewer;
        invV.SetInventory(inventory);
        invV.SetContainerName(name);
        invV.gameObject.SetActive(true);
    }

}
