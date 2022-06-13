using UnityEngine;
using System;
//using UnityEngine.Experimental.Rendering.LWRP;

public class DayTimeSystem : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _globalLight;

    // Update is called once per frame
    void Update()
    {
        _globalLight.intensity += Time.deltaTime / 1000;

    }
}
