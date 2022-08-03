using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Food/ComboFood")]
public class ComboFood : Food
{
    [Space]
    [Header("Food properties")]
    public float waterValue;
    public float foodValue;

    public override void Use()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<ConditionSet>().FoodCondition.UpdateValue(foodValue);
        player.GetComponent<ConditionSet>().WaterCondition.UpdateValue(waterValue);
    }

    public override void Use(Condition condition)
    {
        throw new System.NotImplementedException();
    }
}
