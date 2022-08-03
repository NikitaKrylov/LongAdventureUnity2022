using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Equipment/LightSource")]
public class LightSource : Instrument
{
    [Space]
    [Header("Light properties")]
    public bool canTurnOff;
    public UnityEngine.Rendering.Universal.Light2D.LightType lightType;
    public Color color;
    public float intensity;
    public float pointLightInnerRadius;
    public float pointLightOuterRadius;
    public float pointLightInnerAngle;
    public float pointLightOuterAngle;
    public float zRotation = 0;
}
