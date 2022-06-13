using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class BonfireController : MonoBehaviour
{
    [SerializeField] private List<ParticleSystemElement> particleSystems = new List<ParticleSystemElement>();
    [SerializeField] private new UnityEngine.Rendering.Universal.Light2D light;
    [SerializeField] private float lightFadeValue = 0f;
    [SerializeField] private bool isFadingParticle = true;
    [SerializeField] private bool isFadingLight = true;
    [SerializeField] private bool useParticleSystem = true;

    private void Update()
    {
        FadeAway();
    }

    public virtual void FadeAway()
    {
        if (isFadingParticle) { FadeParticleSystem(); }
        if (isFadingLight) { FadeLight(); }
        
    }

    public void FadeParticleSystem()
    {
        if (!useParticleSystem || particleSystems.Count <= 0) return;

        foreach (ParticleSystemElement p in particleSystems)
        {
            p.Fade();
        }
    }
    public void FadeLight()
    {
        if (light == null) return;

        light.intensity -= lightFadeValue * Time.deltaTime;
    }

    [Serializable]
    private class ParticleSystemElement
    {
        public ParticleSystem particleSystem;
        public float fadeRate = 0f;

        public void Fade()
        {
            var emision = particleSystem.emission;
            var emisionRate = emision.rateOverTime.constant - fadeRate * Time.deltaTime;

            if (emisionRate >= 0f)
            {
                emision.rateOverTime = emisionRate;
            }
            else
            {
                emision.rateOverTime = 0f;
            }
        }
    }

}
