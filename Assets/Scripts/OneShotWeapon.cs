using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotWeapon : ProjectileWeapon {

    //Variables
    private WeaponAgent weaponAgent;
    private Weapon previousWeapon;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Shoot ()
    {
        base.Shoot();
        Destroy(gameObject);
    }
}
