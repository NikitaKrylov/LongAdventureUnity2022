using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 4.3f;
    [SerializeField] private float runningSpeed = 6.5f;
    [SerializeField] private GameObject floatingtextPrefab;
    [SerializeField] private Transform head;
    [SerializeField] private Transform hand;

    public FSM PlayerFSM;
    public FSM WeaponFSM;
    public Inventory inventory;
    public EquipmentSet EquipmentSet;
    private ConditionSet conditionSet;

    private static Player playerInstance;

    public static Player GetInstance()
    {
        return playerInstance;
    }


    private void Start()
    {
        playerInstance = this;
        inventory = new Inventory();
        EquipmentSet = new EquipmentSet(this);
        WeaponFSM = new FSM(gameObject, WeaponState.GetStateByWeaponType(EquipmentSet.weaponSlot));
        PlayerFSM = new FSM(gameObject, new StandingState(PlayerFSM));
        conditionSet = gameObject.GetComponent<ConditionSet>();
    }

    private void Update()
    {
        PlayerFSM.Update();
        WeaponFSM.Update();
    }
    public void Hit(float damageWeight = 1)
    {
        WeaponState weaponState = (WeaponState)WeaponFSM.currentState;
        weaponState.UseWeapon(gameObject, damageWeight);
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

}
