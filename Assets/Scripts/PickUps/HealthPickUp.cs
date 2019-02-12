using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{

    public float healAmount;

    public override void OnPickUp(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.Heal(healAmount);
        }
        base.OnPickUp(target);
    }

}
