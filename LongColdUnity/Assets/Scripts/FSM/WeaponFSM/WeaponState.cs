using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponState : IState
{
    protected EquipmentSet equipmentSet;
    protected Weapon currentWeapon { get { return equipmentSet.weaponSlot; } }

    public abstract IState handleInput(GameObject obj);

    public abstract void OnEnter(GameObject obj);

    public abstract void OnExit();

    public abstract void Update();
    public abstract void UseWeapon(GameObject obj);

    public static WeaponState GetStateByWeaponType(Weapon weapon)
    {
        if (weapon == null) return new NoWeaponState();
        if (weapon is MeleeWeapon) return new MeleeWeaponState();
        if (weapon is FireWeapon) return new FireWeaponState();
        else return new NoWeaponState();
    }
}
