using UnityEngine;
using System;

public class BonfireController : MonoBehaviour
{
    [SerializeField, Tooltip("Добовляются автоматически из дочерних объектов")] private ParticleSystemElement[] particleSystemElements;
    [SerializeField, Tooltip("Общее время работы")] private float workingTime;
    [SerializeField, Tooltip("Порог времени, после которого системы частиц будут изменяться")] private float workingTimeThreshold;
    [SerializeField, Tooltip("Режим работы")] private BonfireWorkType bonfireWorkType = BonfireWorkType.Fade;
    [SerializeField] private float combustionEfficiencyPersent;

    private float CE { get { return combustionEfficiencyPersent / 100; } }



    public enum BonfireWorkType { Stay, Fade }

    private void Start()
    {
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        particleSystemElements = new ParticleSystemElement[particleSystems.Length];

        for (int i = 0; i < particleSystems.Length; i++)
        {
            var pse = new ParticleSystemElement(particleSystems[i], workingTimeThreshold);
            particleSystemElements.SetValue(pse, i);
        }

    }

    private void Update()
    {
        if (bonfireWorkType == BonfireWorkType.Stay) return;

        workingTime -= Time.deltaTime;

        foreach (var pse in particleSystemElements)
        {
            pse.Update(workingTime);
        }
    }

    public void UpdateWorkTime(float fuelValue)
    {
        workingTime += fuelValue * CE;
        // ...
    }

    public void OpenBonfireMenu()
    {
        UIManager.Instance.bonfireComponent.Show();
        BonfireMenu.Instance.SetController(this);
    }

    public int GetWorkTime()
    {
        return (int)workingTime;
    }


    [Serializable]
    private class ParticleSystemElement
    {
        public ParticleSystem particleSystem;
        public float defaultRateOverTime;
        public float currentRateOverTime;
        public bool useWarkingTime = true;
        public readonly float workingTimeThreshold;
        public bool isChanging = true;

        private float fadeSpeed;

        public ParticleSystemElement(ParticleSystem particleSystem,  float workingTimeThreshold)
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

        
    }

}
