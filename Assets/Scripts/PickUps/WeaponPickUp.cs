using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp {

    //Variables
    public Weapon weapon;   //The weapon to give on pick up

    public override void OnPickUp(GameObject target)
    {
        WeaponAgent targetWeaponAgent = target.GetComponent<WeaponAgent>();
        if (targetWeaponAgent != null)
        {
            targetWeaponAgent.Unequip();
            targetWeaponAgent.EquipWeapon(weapon);
            base.OnPickUp(target);
        }
    }
}
