using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponState : WeaponState
{
    private GameObject gameObject;
    private GameObject hand;
    private Animator animator;
    private ComboSystem comboSystem;

    public override IState handleInput(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Q) || equipmentSet.weaponSlot == null)
        {
            return GetStateByWeaponType(null); ;
        }
        else if ( !(currentWeapon is MeleeWeapon) )
        {
            return GetStateByWeaponType(currentWeapon);
        }
        return null;
    }

    public override void OnEnter(GameObject obj)
    {
        equipmentSet = obj.GetComponent<Player>().EquipmentSet;
        gameObject = obj;
        animator = obj.GetComponent<Animator>();
        comboSystem = obj.GetComponent<ComboSystem>();

        foreach (SpriteRenderer o in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            if (o.name == "Hand") hand = o.gameObject;
        }
        hand.GetComponent<SpriteRenderer>().sprite = equipmentSet.weaponSlot.image;


    }

    public override void OnExit()
    {
        hand.GetComponent<SpriteRenderer>().sprite = null;  
    }

    public override void Update()
    {
        //MeleeWeapon weapon = (MeleeWeapon)(equipmentSet.weaponSlot);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    //animator.SetTrigger("SwordHit1");
        //    comboSystem.Play();
        //}
    }

    public override void UseWeapon(GameObject obj, float damageWeight = 1)
    {
        MeleeWeapon weapon = (MeleeWeapon)equipmentSet.weaponSlot;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(obj.transform.position, weapon.distance.x, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            var cr = hit.transform.gameObject.GetComponent<Creature>();

            if (cr != null) cr.Damage(equipmentSet.weaponSlot.CountDamage() * damageWeight);
        }
        
    }
}
