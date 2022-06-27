using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{

}

public abstract class Weapon : Equipment
{
    public float baseDamage;
    //public DamageType damageType;

    public abstract void Damage();
    public abstract void Damage(Condition condition);
    public abstract float CountDamage();
}
