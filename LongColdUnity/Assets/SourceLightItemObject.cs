using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D)), ExecuteInEditMode]
public class SourceLightItemObject : MainItemObject
{
    public Light2D lightSource;

    public override void Init()
    {
        base.Init();

        if (objectModel is not LightSource) throw new Exception($"'{objectModel}' должен быть типа 'LightSource'");

        lightSource = GetComponentInChildren<Light2D>();
        lightSource.lightType = ((LightSource)objectModel).lightType;

        lightSource.intensity = ((LightSource)objectModel).intensity;   
        lightSource.color = ((LightSource)objectModel).color;
        lightSource.pointLightOuterRadius = ((LightSource)objectModel).pointLightOuterRadius;
        lightSource.pointLightInnerRadius = ((LightSource)objectModel).pointLightInnerRadius;
        lightSource.pointLightInnerAngle = ((LightSource)objectModel).pointLightInnerAngle;
        lightSource.pointLightOuterAngle = ((LightSource)objectModel).pointLightOuterAngle;

    }
}
