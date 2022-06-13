using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSet : MonoBehaviour
{
    [Header("Conditions")]
    public Condition HealthCondition;
    public Condition FoodCondition;
    public Condition TemperatureCondition;
    public Condition WaterCondition;

    private Condition[] _conditions;

    [Header("Condition changing settings")]
    public bool isUpdatable = true;

    private void Start()
    {
        _conditions = new Condition[]
        {
            HealthCondition,
            FoodCondition,
            TemperatureCondition,
            WaterCondition
        };
    }

    private void Update()
    {
        if (isUpdatable)
        {
            foreach (Condition condition in _conditions)
            {
                condition.Update(Time.deltaTime);
            }
        }
    }
}
