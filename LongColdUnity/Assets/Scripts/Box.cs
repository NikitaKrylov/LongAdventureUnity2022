using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Container container;


    public void Open()
    {
        UIManager uiManager = UIManager.Instance;
        uiManager.inventoryComponent.Show();

        ContainerViewer cv = uiManager.containerViewer;
        cv.gameObject.SetActive(true);
        cv.Show(container);
    }
}
