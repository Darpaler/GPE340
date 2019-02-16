using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{
    //Variables
    public float healAmount;    //How much the player should heal

    //Health on pickup
    public override void OnPickUp(GameObject target)
    {
        //If they have health
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            //Heal them
            targetHealth.Heal(healAmount);
        }

        //Run the base pickup on pickup
        base.OnPickUp(target);
    }

}
