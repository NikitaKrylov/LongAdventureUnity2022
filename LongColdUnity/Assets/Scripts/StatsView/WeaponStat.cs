using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStat : BaseItemStatView
{
    [SerializeField] protected Text weaponForce;
    [SerializeField] protected Button button2;
    private EquipmentSet equipmentSet;

    protected override void SetAbstractItemData(AbstractItem obj)
    {
        base.SetAbstractItemData(obj);
        equipmentSet = Player.GetInstance().EquipmentSet;
        weaponForce.text = ((Weapon)obj).baseDamage.ToString();

        SetButtonText((Weapon)obj);

        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(delegate {
            SetButtonAction((Weapon)obj);
            SetButtonText((Weapon)obj);
        });
    }

    protected override void SetInventoryViewCellData(InventoryViewCell obj)
    {
        base.SetInventoryViewCellData(obj);
    }

    protected override void SetItemData(Item obj)
    {
        base.SetItemData(obj);
    }
    private void SetButtonAction(Weapon obj)
    {
        if (equipmentSet.weaponSlot == null) equipmentSet.SetWeapon(obj);
        else if (equipmentSet.weaponSlot == obj)equipmentSet.SetWeapon(null);
        else equipmentSet.SetWeapon(obj);
        
    }
    private void SetButtonText(Weapon obj)
    {
        if (equipmentSet.weaponSlot == null) button2.GetComponentInChildren<Text>().text = "Set";
        else if (equipmentSet.weaponSlot == obj) button2.GetComponentInChildren<Text>().text = "Remove";
        else button2.GetComponentInChildren<Text>().text = "Replace";
        
    }

}
