using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickUp : PickUp
{
    //Variables
    public float damageAmount;  //How much to damage the player

    public override void OnPickUp(GameObject target)
    {
        //If they have health
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            //Damage the player
            targetHealth.TakeDamage(damageAmount);
        }
        //Run the base pickup on pickup
        base.OnPickUp(target);
    }
}
