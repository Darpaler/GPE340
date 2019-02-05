using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickUp : PickUp
{

    public float damageAmount;

    public override void OnPickUp(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damageAmount);
        }

        base.OnPickUp(target);
    }
}
