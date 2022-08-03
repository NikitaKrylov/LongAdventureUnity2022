using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponState : WeaponState
{
    private GameObject gameObject;
    private GameObject hand;
    private Animator animator;
    private MeleeFightSystem meleeFightSystem;

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
        meleeFightSystem = obj.GetComponent<MeleeFightSystem>();

        foreach (SpriteRenderer o in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            if (o.name == "Hand") hand = o.gameObject;
        }
        hand.GetComponent<SpriteRenderer>().sprite = equipmentSet.weaponSlot.image;
        hand.transform.localScale = new Vector3(
            hand.transform.localScale.x / obj.transform.localScale.x * equipmentSet.weaponSlot.scale.x,
            hand.transform.localScale.y / obj.transform.localScale.y * equipmentSet.weaponSlot.scale.y,
            hand.transform.localScale.z / obj.transform.localScale.z * equipmentSet.weaponSlot.scale.z
            );


    }

    public override void OnExit()
    {
        hand.GetComponent<SpriteRenderer>().sprite = null;
        hand.transform.localScale = Vector3.one;
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            meleeFightSystem.Play();
        }
    }

    public override void UseWeapon(GameObject obj, float damageWeight = 1)
    {
        MeleeWeapon weapon = (MeleeWeapon)equipmentSet.weaponSlot;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(obj.transform.position, weapon.distance.x, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            var cr = hit.transform.gameObject.GetComponent<IMob>();

            if (cr != null) cr.TakeDamage(equipmentSet.weaponSlot.CountDamage() * damageWeight);
        }
        
    }
}
