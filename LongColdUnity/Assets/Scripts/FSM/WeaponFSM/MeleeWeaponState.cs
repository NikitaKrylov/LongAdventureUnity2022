using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponState : WeaponState
{
    private GameObject gameObject;
    public override IState handleInput(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return GetStateByWeaponType(null); ;
        }
        return null;
    }

    public override void OnEnter(GameObject obj)
    {
        equipmentSet = obj.GetComponent<Player>().EquipmentSet;
        gameObject = obj;
    }

    public override void OnExit(){}

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseWeapon(gameObject);
        }
    }

    public override void UseWeapon(GameObject obj)
    {
        MeleeWeapon weapon = (MeleeWeapon)equipmentSet.weaponSlot;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(obj.transform.position, weapon.distance.x, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            var cr = hit.transform.gameObject.GetComponent<Creature>();
            Debug.Log(hit.transform.gameObject.name);

            if (cr != null) cr.Damage(equipmentSet.weaponSlot.CountDamage());
        }
        
    }
}
