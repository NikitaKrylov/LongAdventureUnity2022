using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourcePrefab : MainItemObject
{
    protected UnityEngine.Rendering.Universal.Light2D lightSource;

    public override void Init()
    {
        base.Init();
        lightSource = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }
}
