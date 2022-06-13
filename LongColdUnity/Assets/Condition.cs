using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Condition
{
    public string name;
    public static float maxValue { get; private set; } = 1000;
    public float Value { get; private set; } = 500;


    public enum ChangingForce {
        StrongIncrease,
        Increase,
        None,
        Decrease,
        StrongDecrease,
        
    }
    public ChangingForce changingForce = ChangingForce.None;
    public ConditionView conditionView;

    public float normalizedValue { 
        get { 
            if (Value == 0f) return 0f;
            return Value / maxValue;   
        } 
    }

    public void SetValue(float newValue, bool animated = false)
    {
      
        if (newValue < 0f) Value = 0f;
        else if (newValue > maxValue) Value = maxValue;
        else Value = newValue;

        if (animated) conditionView.UpdateAnimatedFillAmount(normalizedValue);
        else conditionView.UpdateFillAmount(normalizedValue);
        
    }
    public void UpdateValue(float value, bool animated = false)
    {
        SetValue(this.Value + value, animated);
    }
    public virtual float GetChangingValue(ChangingForce changingForce)
    {
        switch (changingForce)
        {
            case ChangingForce.StrongIncrease:
                return 2;
            case ChangingForce.Increase:
                return .5f;
            case ChangingForce.None:
                return 0;
            case ChangingForce.Decrease:
                return -.5f;
            case ChangingForce.StrongDecrease:
                return -2;
            default:
                return 0;
        }
    }

    //Предполагается вызов в каждом кадре
    // для корректного изменение требуется deltaTime
    public virtual void Update(float deltaTime = 1f)
    {
        float value = GetChangingValue(changingForce);
        UpdateValue(value * deltaTime);
    }
    
}
