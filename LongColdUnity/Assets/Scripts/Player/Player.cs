using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        WeaponFSM = new FSM(gameObject, new NoWeaponState());
        PlayerFSM = new FSM(gameObject, new StandingState());
        conditionSet = gameObject.GetComponent<ConditionSet>();
    }

    private void Update()
    {
        PlayerFSM.Update();
        WeaponFSM.Update();

        //if (Input.GetMouseButtonDown(0)) Hit();
    }
    public void Damage(float value)
    {
        conditionSet.HealthCondition.UpdateValue(value, true);
    }
    public void Hit()
    {
        WeaponState weaponState = (WeaponState)WeaponFSM.currentState;
        weaponState.UseWeapon(gameObject);
    }

}
