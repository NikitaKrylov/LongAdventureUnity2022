using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private EquipmentSet equipmentSet { get { return player.EquipmentSet; } }
    private ComboHit currentComboHit = null;
    private ComboHit startComboHit { get { return GetMeleeWeapon()?.comboHit;  } }
    private Animator animator;
    private Player player;

    public bool isActive { get; private set; } = false;
    private float time = 0;

    public MeleeWeapon GetMeleeWeapon()
    {
        if (equipmentSet.weaponSlot is MeleeWeapon)
        {
            return (MeleeWeapon)(equipmentSet.weaponSlot);
        }
        else
        {
            return null;
        }
    }

    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentComboHit == null || time > currentComboHit.clipLength + currentComboHit.addedOffset)
        {
            isActive = false;
        }

        if (isActive)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
        }
    }

    public void Play()
    {
        if (GetMeleeWeapon() == null) return;


        if (isActive) // последующие нажати€ в тайминг
        {

            if (time <= currentComboHit.clipLength + currentComboHit.addedOffset)
            {
                var nextCombo = currentComboHit.nextComboHit;
                if (nextCombo != null)
                {
                    currentComboHit.Stop(animator);
                    currentComboHit = nextCombo;
                    currentComboHit.Play(animator);
                }
                else
                {
                    currentComboHit = startComboHit;
                    isActive = false;
                }
            }
        }
        else //первое нажатие
        {
            currentComboHit = startComboHit;
            currentComboHit.Play(animator);
            isActive = true;

        }
    }

    private bool CanChangeCombo()
    {
        if (time <= currentComboHit.clipLength )
        {
            return true;
        }
        return false;
    }

    public void MakeTransformChanging()
    {
        if (currentComboHit == null) return;

        var obj = animator.gameObject;

        if (currentComboHit.useRigidbody2DChanging)
        {
            Vector2 force = currentComboHit.force;
            force.x = Mathf.Abs(force.x) * Mathf.Sign(obj.transform.localScale.x);
            obj.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
        }
    }
}
