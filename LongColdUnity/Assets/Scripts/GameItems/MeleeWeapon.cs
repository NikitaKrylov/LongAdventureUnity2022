using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Equipment/Weapon/MeleeWeapon")]
public class MeleeWeapon : Weapon
{
    public Vector2 distance;
    public ComboHit comboHit;
    public override float CountDamage()
    {
        return baseDamage;
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
