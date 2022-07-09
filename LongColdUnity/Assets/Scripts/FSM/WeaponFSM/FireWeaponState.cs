using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeaponState : WeaponState
{
    private GameObject hand;
    private Camera m_Camera;
    private GameObject gameObject;
    private AudioSource audioSource;
    public override IState handleInput(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Q) || currentWeapon == null)
        {
            return GetStateByWeaponType(null); ;
        }
        else if ( !(currentWeapon is FireWeapon) )
        {
            return GetStateByWeaponType(currentWeapon);
        }    
        return null;
    }

    public override void OnEnter(GameObject obj)
    {
        gameObject = obj;
        audioSource = gameObject.GetComponent<AudioSource>();
        equipmentSet = obj.GetComponent<Player>().EquipmentSet;
        m_Camera = Camera.main;

        foreach (SpriteRenderer o in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            if (o.name == "Hand") hand = o.gameObject;
        }
        hand.GetComponent<SpriteRenderer>().sprite = currentWeapon.image;

    }

    public override void OnExit()
    {
        hand.GetComponent<SpriteRenderer>().sprite = null;

    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseWeapon(gameObject);
        }
    }


    public override void UseWeapon(GameObject obj)
    {
        var fireSound = ((FireWeapon)currentWeapon).fireSound;
        if (fireSound != null) audioSource.PlayOneShot(fireSound);


        var pos = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapPointAll(pos);

        foreach (Collider2D collider in colliders)
        {
            var cr = collider.transform.gameObject.GetComponent<Creature>();

            if (cr != null) cr.Damage(currentWeapon.CountDamage());
        }
    }
}
