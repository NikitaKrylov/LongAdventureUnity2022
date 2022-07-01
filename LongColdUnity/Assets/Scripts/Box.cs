using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Inventory inventory;
    private AudioSource openSound;
    [SerializeField] private List<Item> items = new List<Item>();

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
        invV.gameObject.SetActive(true);
    }

}
