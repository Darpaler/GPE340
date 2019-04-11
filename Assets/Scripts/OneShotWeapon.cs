using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotWeapon : ProjectileWeapon {

    //Variables
    private WeaponAgent weaponAgent;

    void Start()
    {
        //Get Components
        weaponAgent = GetComponent<WeaponAgent>();
    }

    //Destroy Oneshot weapons after use
    protected override void Shoot ()
    {
        base.Shoot();
        if (triggerPulled)
        {
            weaponAgent.Unequip();
            weaponAgent.attachmentPoint.GetChild(0).gameObject.SetActive(true);
        }
       
    }
}
