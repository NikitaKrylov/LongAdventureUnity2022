using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeFightSystem : BaseFightSystem
{
    private Player player;
    private Animator animator;
    private MeleeWeapon weapon { get { return (MeleeWeapon)player.EquipmentSet.weaponSlot; } }
    private ComboHit currentCombo;
    private ComboHit startCombo { get { return weapon.comboHit; } }
    private bool isActive = false;
    private bool switchToNextComboHit = false;

    private void Start()
    {
        player = GetComponent<Player>();    
        animator = GetComponent<Animator>();
    }
    public override void Play()
    {
        if (!isActive)
        {
            currentCombo = startCombo;
            currentCombo.Play(animator);
        }
        else
        {
            if (currentCombo.nextComboHit != null)
            {
                switchToNextComboHit = true;

            }
        }
    }

    
    public void OnAnimationStart()
    {
        isActive = true;
        switchToNextComboHit = false;
    }
    public void OnAnimationEnd()
    {
        if (switchToNextComboHit)
        {
            currentCombo = currentCombo.nextComboHit;
            currentCombo.Play(animator);
            switchToNextComboHit = false;
        }
        isActive = false;

    }

    public void MakeTransformChanges()
    {
        var force = currentCombo.rigidbody2DForce;
        force.x *= Mathf.Sign(player.transform.localScale.x);
        player.gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
    }

    public override void UseWeapon()
    {
        throw new System.NotImplementedException();
    }
}
