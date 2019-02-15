using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotWeapon : ProjectileWeapon {

	// Update is called once per frame
	protected override void Shoot ()
    {
        base.Shoot();
        if (triggerPulled)
        {
            Destroy(gameObject);
        }
       
    }
}
