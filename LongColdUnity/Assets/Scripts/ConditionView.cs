using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionView : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image[] images;
    [SerializeField] private Slider slider;
    [SerializeField] private float updatingTime = 2f;
    private float FillValue;
    private bool isAnimating = false;

    private void UpdateObjects(float value)
    {
        if (images.Length > 0)
            foreach (Image image in images)
            {
                image.fillAmount = value;
                image.color = gradient.Evaluate(value);
            }

        if (slider != null)
            slider.value = value;
    }

    public void UpdateFillAmount(float normalizedValue)
    {
        if (isAnimating) return;

        FillValue = normalizedValue;
        UpdateObjects(normalizedValue);
    }

    public void UpdateAnimatedFillAmount(float normalizedValue)
    {
        isAnimating = true;
        StartCoroutine(AnimateValue(normalizedValue));
    }

    IEnumerator AnimateValue(float normalizedValue)
    {
        for (float i = 0f; i < 1; i+= Time.deltaTime / updatingTime)
        {
            float rez = Mathf.Lerp(FillValue, normalizedValue, i);
            UpdateObjects(rez);

            yield return null;

        }
        UpdateObjects(normalizedValue);
        isAnimating = false;
    }
    
}
