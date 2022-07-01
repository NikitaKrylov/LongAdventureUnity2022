using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Equipment/LightSource")]
public class LightSource : Instrument
{
    public bool canTurnOff;
    public Light2D.LightType lightType;
    public Color color;
    public float intensity;
    public float pointLightInnerRadius;
    public float pointLightOuterRadius;
    public float pointLightInnerAngle;
    public float pointLightOuterAngle;
    public float zRotation = 0;
}
