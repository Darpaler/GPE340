using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotWeapon : ProjectileWeapon {

    //Destroy Oneshot weapons after use
	protected override void Shoot ()
    {
        base.Shoot();
        if (triggerPulled)
        {
            Destroy(gameObject);
        }
       
    }
}
