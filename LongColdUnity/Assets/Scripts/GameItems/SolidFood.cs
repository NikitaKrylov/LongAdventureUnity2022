using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Food/SolidFood")]
public class SolidFood : Food
{
    [Space]
    [Header("Food properties")]
    public float foodValue;

    public override void Use()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        Use(player.GetComponent<ConditionSet>().FoodCondition);
    }

    public override void Use(Condition condition)
    {
        condition.UpdateValue(foodValue, true);
    }
}
