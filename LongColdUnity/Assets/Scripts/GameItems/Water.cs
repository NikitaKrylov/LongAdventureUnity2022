using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Food/Water")]
public class Water : Food
{
    public float waterValue;
    public override void Use() 
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        Use(player.GetComponent<ConditionSet>().WaterCondition);
    }

    public override void Use(Condition condition)
    {
        condition.UpdateValue(waterValue, true);
    }
}
