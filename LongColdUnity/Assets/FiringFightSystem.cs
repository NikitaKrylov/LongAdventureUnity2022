using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class FiringFightSystem : BaseFightSystem
{
    private Player player;
    private FireWeapon weapon { get { return (FireWeapon)player.EquipmentSet.weaponSlot; } }
    private float time = 0f;


    private void Start()
    {
        player = GetComponent<Player>();
    }
    public override void Play()
    {
        if (time > weapon.cooldown)
        {
            player.Hit();
            time = 0f;
        }
    }

    public override void UpdateSystem()
    {
        time += Time.deltaTime;
    }
}
