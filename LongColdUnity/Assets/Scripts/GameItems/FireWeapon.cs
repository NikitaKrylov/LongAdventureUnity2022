using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Equipment/Weapon/FireWeapon")]
public class FireWeapon : Weapon
{
    public Ammo requiredAmmo;
    public override float CountDamage()
    {
        return requiredAmmo.force + baseDamage;
    }

    public override void Damage()
    {
        throw new System.NotImplementedException();
    }

    public override void Damage(Condition condition)
    {
        throw new System.NotImplementedException();
    }
}
