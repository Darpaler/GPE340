using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp {

    //Variables
    public Weapon weapon;   //The weapon to give on pick up

    public override void OnPickUp(GameObject target)
    {
        //If they can hold a weapon
        WeaponAgent targetWeaponAgent = target.GetComponent<WeaponAgent>();
        if (targetWeaponAgent != null)
        {
            //Unequip their last weapon
            targetWeaponAgent.Unequip();

            //Equip the new weapon
            targetWeaponAgent.EquipWeapon(weapon);

            //Run the base pickup on pickup
            base.OnPickUp(target);
        }
    }
}
