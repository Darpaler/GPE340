using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotWeaponPickUp : WeaponPickUp {
    public override void OnPickUp(GameObject target)
    {
        //Get Components
        targetWeaponAgent = target.GetComponent<WeaponAgent>();
        targetRagdoll = target.GetComponent<RagdollControls>();

        //If they can hold a weapon
        if (targetWeaponAgent != null)
        {
            //Hide their last weapon
            targetWeaponAgent.attachmentPoint.GetChild(0).gameObject.SetActive(false);

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
