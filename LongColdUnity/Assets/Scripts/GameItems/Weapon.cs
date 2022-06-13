using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{

}

public abstract class Weapon : Equipment
{
    public float damage;
    public DamageType damageType;

    public abstract void Damage();
    public abstract void Damage(Condition condition);
}
