using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentSet  
{
    public Weapon weaponSlot { get; private set; } = null;
    public Equipment firstEquipmentSlot { get; set; } = null;
    public Equipment secindEquipmentSlot { get; set; } = null;

    public void SetWeapon(Weapon weapon)
    {
        weaponSlot = weapon;

        if (weapon == null)
        {
            //weaponFSM.SetState(new NoWeaponState());
        }
        else if (weapon is MeleeWeapon)
        {
            //weaponFSM.SetState(new MeleeWeaponState());
        }
        else if (weapon is FireWeapon)
        {
            //throw new Exception("FireWeaponState ��� �� ������, ����� ������������ ��������� FireWeapon");
        }
    }
}
