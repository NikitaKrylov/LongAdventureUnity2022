using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ConditionArea : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    [SerializeField] private ConditionChangingForce conditionChangingForce = ConditionChangingForce.None;
    [SerializeField] private ConditionType conditionType = ConditionType.Temperature;

    public enum ConditionType
    {
        Temperature,
        Health
    }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ConditionSet set = collision.gameObject.GetComponent<ConditionSet>();
        if (set == null) return;

        ChangeCondition(set);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ConditionSet set = collision.gameObject.GetComponent<ConditionSet>();
        if (set == null) return;

    }


    private void ChangeCondition(ConditionSet set)
    {
        switch (conditionType)
        {
            case ConditionType.Temperature:
                set.TemperatureCondition.changingForce = conditionChangingForce;
                return;

        }
    }
    //private void RemoveCondition(ConditionSet set)
    //{
    //    switch (conditionType)
    //    {
    //        case ConditionType.Temperature:
    //            set.TemperatureCondition.changingForce = ConditionChangingForce.None;
    //            return;

    //    }
    //}
}
