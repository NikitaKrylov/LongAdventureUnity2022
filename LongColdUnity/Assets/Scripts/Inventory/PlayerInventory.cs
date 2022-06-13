using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    private static PlayerInventory _instance;

    private void Awake()
    {
        _instance = this;
    }

    
    public static PlayerInventory GetInstance()
    {
        return _instance;
    }
}
