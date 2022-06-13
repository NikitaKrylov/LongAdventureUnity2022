using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    Head,
    Body,
    Heands
}

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Equipment/Сlothes")]
public class Сlothes : Equipment
{
    public float coldProtection;
    public float hurtProtection;
    public BodyType bodyType;
}
