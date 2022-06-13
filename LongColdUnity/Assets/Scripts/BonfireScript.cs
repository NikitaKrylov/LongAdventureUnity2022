using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{
    [SerializeField]private ParticleSystem _fireSystem;
    [SerializeField] private bool _isDecayable = false;
    [SerializeField] private float _decayRate = 1;
    private float emisionRate;

    private void Start()
    {
        emisionRate = _fireSystem.emission.rateOverTime.constant;
    }


    private void Update()
    {
        if (_isDecayable)
        {
            Decay();
        }
    }

    private void Decay()
    {
        var emision = _fireSystem.emission;
        emisionRate -= Time.deltaTime * _decayRate;
        emision.rateOverTime = emisionRate;
    }
}
