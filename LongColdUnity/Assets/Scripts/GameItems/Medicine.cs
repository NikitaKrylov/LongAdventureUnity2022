using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Medicine/Medicine")]
public class Medicine : AbstractItem
{
    public float recoveringValue;
    public void Use()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        Use(player.GetComponent<ConditionSet>().HealthCondition);
    }
    public void Use(Condition condition)
    {
        condition.UpdateValue(recoveringValue, true);
    }

}
