using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IFightable
{
    [SerializeField] private float walkingSpeed = 4.3f;
    [SerializeField] private float runningSpeed = 6.5f;
    [SerializeField] private GameObject floatingtextPrefab;
    [SerializeField] private Transform head;
    [SerializeField] private Transform hand;

    public StateMachine<Player> playerStateMachine;
    public Inventory inventory;
    public EquipmentSet EquipmentSet;
    private ConditionSet conditionSet;

    private static Player playerInstance;

    public float damageValue => throw new System.NotImplementedException();

    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public static Player GetInstance()
    {
        return playerInstance;
    }


    private void Start()
    {
        playerInstance = this;
        inventory = new Inventory();
        EquipmentSet = new EquipmentSet();
        playerStateMachine = new StateMachine<Player>(this, new StandingState(playerStateMachine));
        conditionSet = gameObject.GetComponent<ConditionSet>();
    }

    private void Update()
    {
        playerStateMachine.Update();
    }
    
    public void TakeDamage(float value)
    {
        var obj = Instantiate(floatingtextPrefab, transform.position, Quaternion.identity, transform.parent);
        obj.GetComponent<TextMeshPro>().text = value.ToString();
        conditionSet.HealthCondition.UpdateValue(-value, false);
    }
    public void ShowFloatingText(string text, Color color)
    {
        GameObject floatingText = Instantiate(floatingtextPrefab, head.position, Quaternion.identity, transform.parent);
        TextMeshPro tmp = floatingText.GetComponent<TextMeshPro>();
        tmp.color = color;
        tmp.text = text;
    }

    public float GetWalkingSpeed() => walkingSpeed;
    public float GetRunningSpeed() => runningSpeed;

    public void Attack(IFightable entity)
    {
        throw new System.NotImplementedException();
    }

    public void Damage(float value)
    {
        throw new System.NotImplementedException();
    }

    public void Kill()
    {
        throw new System.NotImplementedException();
    }
}
