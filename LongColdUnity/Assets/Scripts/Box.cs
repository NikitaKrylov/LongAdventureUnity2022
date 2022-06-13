using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Container container;
    [SerializeField] private GameObject inventoryObject;


    public void Open()
    {
        UIManager uiManager = UIManager.Instance;
        uiManager.inventoryComponent.Show();

        ContainerViewer cv = uiManager.containerViewer;
        cv.gameObject.SetActive(true);
        cv.Show(container);
    }
}
