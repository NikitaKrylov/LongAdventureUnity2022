using UnityEngine;
using System;
//using UnityEngine.Experimental.Rendering.LWRP;

public class DayTimeSystem : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _globalLight;
    [SerializeField] private SpriteRenderer bacground;
    [SerializeField] private Gradient bacgroundGradient;
    private float _time = 0f;

    public float Time { get { return _time; } }

    // Update is called once per frame
    void Update()
    {
        _globalLight.intensity += UnityEngine.Time.deltaTime / 1000;

    }
}
