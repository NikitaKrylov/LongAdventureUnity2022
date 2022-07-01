using UnityEngine;
using System;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;

public class BonfireController : MonoBehaviour
{
    [SerializeField, Tooltip("Добовляются автоматически из дочерних объектов")] private ParticleSystemElement[] particleSystemElements;
    [SerializeField, Tooltip("Добовляются автоматически из дочерних объектов")] private LightElement[] lightElements;
    [SerializeField, Tooltip("Общее время работы")] private float workingTime;
    [SerializeField, Tooltip("Порог времени, после которого системы частиц будут изменяться")] private float workingTimeThreshold;
    [SerializeField, Tooltip("Состояние источника огня")] public BonfireWorkType bonfireWorkType = BonfireWorkType.Fading;
    [SerializeField] private float combustionEfficiencyPersent;

    private float CE { get {
            if (bonfireWorkType == BonfireWorkType.Extinct) return combustionEfficiencyPersent / 100 / 3;
            return combustionEfficiencyPersent / 100; 
        } }

    public enum BonfireWorkType { Extinct, Fading, Staying }

    private void Start()
    {
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        Light2D[] lights = GetComponentsInChildren<Light2D>();

        particleSystemElements = new ParticleSystemElement[particleSystems.Length];
        lightElements = new LightElement[lights.Length];

        for (int i = 0; i < particleSystems.Length; i++)
        {
            var pse = new ParticleSystemElement(particleSystems[i], workingTimeThreshold);
            particleSystemElements.SetValue(pse, i);
        }

        for (int i = 0;i < lights.Length; i++)
        {
            var lc = new LightElement(lights[i], workingTimeThreshold);
            lightElements.SetValue(lc, i);
        }

    }

    private void Update()
    {
        if (bonfireWorkType == BonfireWorkType.Staying || bonfireWorkType == BonfireWorkType.Extinct) return;

        if (workingTime - Time.deltaTime <= 0)
        {
            bonfireWorkType = BonfireWorkType.Extinct;
            return;
        }

        workingTime -= Time.deltaTime;

        foreach (var pse in particleSystemElements)
        {
            pse.Update(workingTime);
        }
        foreach (var le in lightElements)
        {
            le.Update(workingTime);
        }
    }

    public void UpdateWorkTime(float fuelValue)
    {
        workingTime += fuelValue * CE;

        if (workingTime >= workingTimeThreshold)
        {
            bonfireWorkType = BonfireWorkType.Fading;
            foreach (var pse in particleSystemElements) pse.Release();
            foreach (var le in lightElements) le.Release();
        }
    }

    public void OpenBonfireMenu()
    {
        UIManager.Instance.bonfireComponent.Show();
        BonfireMenu.Instance.SetController(this);
    }

    public float GetWorkTime()
    {
        return workingTime;
    }
    public float GetWorkTimeThreshold()
    {
        return workingTimeThreshold;
    }





    [Serializable]
    private class ParticleSystemElement
    {
        private ParticleSystem particleSystem;
        [SerializeField] private float defaultRateOverTime;
        [SerializeField] private float currentRateOverTime;
        private readonly float workingTimeThreshold;
        private float fadeSpeed;

        public ParticleSystemElement(ParticleSystem particleSystem, float workingTimeThreshold)
        {
            this.particleSystem = particleSystem;
            this.workingTimeThreshold = workingTimeThreshold;

            var emmision = this.particleSystem.emission;
            defaultRateOverTime = emmision.rateOverTime.constant;
            currentRateOverTime = defaultRateOverTime;
            fadeSpeed = defaultRateOverTime / workingTimeThreshold;
        }

        public void Update(float workingTime)
        {
            if (workingTime - workingTimeThreshold <= 0) Fade();
        }

        public void Fade()
        {
            var emmision = particleSystem.emission;

            if (currentRateOverTime - fadeSpeed * Time.deltaTime <= 0) return;

            currentRateOverTime -= fadeSpeed * Time.deltaTime;
            emmision.rateOverTime = currentRateOverTime;
        }
        public void Release()
        {
            currentRateOverTime = defaultRateOverTime;
            var emmision = particleSystem.emission;
            emmision.rateOverTime = currentRateOverTime;

        }


    }

    [Serializable]
    private class LightElement
    {
        private Light2D light;
        [SerializeField] private float defaultIntensity;
        [SerializeField] private float currentIntensity;
        private float fadeSpeed;
        private float workingTimeThreshold;

        public LightElement(Light2D light, float workingTimeThreshold)
        {
            this.light = light;
            defaultIntensity = light.intensity;
            currentIntensity = defaultIntensity;
            this.workingTimeThreshold = workingTimeThreshold;
            fadeSpeed = defaultIntensity / workingTimeThreshold;
        }

        public void Fade()
        {
            if (currentIntensity - fadeSpeed * Time.deltaTime <= 0) return;

            currentIntensity -= fadeSpeed * Time.deltaTime;
            light.intensity = currentIntensity;
        }
        public void Update(float workingTime)
        {
            if (workingTime - workingTimeThreshold <= 0) Fade();
        }
        public void Release()
        {
            currentIntensity = defaultIntensity;
            light.intensity = currentIntensity;

        }
    }

}
