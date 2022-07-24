using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSystem : MonoBehaviour
{

    private EquipmentSet equipmentSet;
    private FireWeapon weapon { get { 
            if (equipmentSet.weaponSlot is FireWeapon) return (FireWeapon)equipmentSet.weaponSlot;
            else return null;
                } }
    public bool isActive { get; private set; } = false;
    private float time;


    void Start()
    {
        equipmentSet = Player.GetInstance().EquipmentSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
