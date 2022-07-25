using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeaponState : WeaponState
{
    public override IState handleInput(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return GetStateByWeaponType(equipmentSet.weaponSlot);
        }
        return null;
    }

    public override void OnEnter(GameObject obj)
    {
        equipmentSet = obj.GetComponent<Player>().EquipmentSet;
    }

    public override void OnExit()
    {
    }
    public override void Update()
    {
    }

    public override void UseWeapon(GameObject obj, float damageWeight)
    {
    }
}
