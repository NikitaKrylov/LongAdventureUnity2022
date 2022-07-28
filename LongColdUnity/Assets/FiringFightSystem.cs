using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class FiringFightSystem : BaseFightSystem
{
    private Player player;
    private MeleeWeapon weapon { get { return (MeleeWeapon)player.EquipmentSet.weaponSlot; } }


    private void Start()
    {
        player = GetComponent<Player>();
    }
    public override void Play()
    {
        
    }

    public override void UseWeapon()
    {
        throw new System.NotImplementedException();
    }
}
