using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    public InventoryViewer containerViewer;
    [SerializeField] private GameObject playerUINavigationBar;
    public UIAggregator aggregator;
    public AggregationComponent inventoryComponent;
    public AggregationComponent craftComponent;
    public AggregationComponent bonfireComponent;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) inventoryComponent.Execute();
        if (Input.GetKeyDown(KeyCode.C)) craftComponent.Execute();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            aggregator.CloseAll();
            RestoreTime();
            playerUINavigationBar.SetActive(false);
        }

    }

    private static void StopTime() => Time.timeScale = 0;
    private static void RestoreTime() => Time.timeScale = 1;

    
}
