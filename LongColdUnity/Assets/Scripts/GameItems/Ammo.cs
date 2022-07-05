using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{

}

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Material/Ammo")]
public class Ammo : Material
{
    public float force;
    public AmmoType ammoType;
}
