using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class FiringFightSystem : BaseFightSystem
{
    [SerializeField] private RectTransform aimPoint;

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
    
    public void ShowAimPoint()
    {
        aimPoint.gameObject.SetActive(true);
        Cursor.visible = false;
    }

    public void HideAimPoint()
    {
        aimPoint.gameObject.SetActive(false);
        Cursor.visible = true;
    }
    public void UpdateaimPointPos(Vector3 pos)
    {
        aimPoint.gameObject.transform.position = pos;
    }
}
