using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FiringMode
{
    Automatic,
    SingleShot,
    SemiAutomatic
}


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Equipment/Weapon/FireWeapon")]
public class FireWeapon : Weapon
{
    public AmmoType requiredAmmoType;
    public FiringMode firingMode;
    public float maxDistance;
    public AudioClip fireSound;
    public float cooldown;

    public override float CountDamage()
    {
        return  baseDamage;
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
