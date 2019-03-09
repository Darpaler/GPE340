using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp {

    //Variables
    public Weapon weapon;               //The weapon to give on pick up
    WeaponAgent targetWeaponAgent;      //The target's Weapon Agent
    private RagdollControls targetRagdoll;    //The target's Ragdoll Controls component

    public override void OnPickUp(GameObject target)
    {
        //Get Components
        targetWeaponAgent = target.GetComponent<WeaponAgent>();
        targetRagdoll = target.GetComponent<RagdollControls>();

        //If they can hold a weapon
        if (targetWeaponAgent != null)
        {
            //Unequip their last weapon
            targetWeaponAgent.Unequip();

            //Equip the new weapon
            targetWeaponAgent.EquipWeapon(weapon);

            //Run the base pickup on pickup
            base.OnPickUp(target);

            //Reset their colliders to include the weapon
            if (targetRagdoll != null)
            {
                targetRagdoll.partColliders[targetRagdoll.partColliders.Count - 1] = targetWeaponAgent.equippedWeapon.GetComponent<Collider>();
            }
        }
    }
}
