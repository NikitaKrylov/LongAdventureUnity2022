using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image[] fills;
    [SerializeField] private Gradient fillGradient;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateFills(healthSlider.normalizedValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Damage(5f);
        }
    }


    public void Damage(float damage) => SetValue(currentHealth - damage);
    public void Heal(float value) => SetValue(currentHealth + value);

    private void SetValue(float value)
    {
        if (value >= 0 && value <= maxHealth)
            currentHealth = value;
            healthSlider.value = currentHealth;
            UpdateFills(healthSlider.normalizedValue);
    }


    private void UpdateFills(float value)
    {
        for (int i = 0; i < fills.Length; i++)
        {
            fills[i].color = fillGradient.Evaluate(healthSlider.normalizedValue);
        }
        

    }


}
