using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotWeapon : ProjectileWeapon {

    //Variables
    [SerializeField]
    private WeaponAgent weaponAgent;

    private GameObject parentGameObject;

    void Start()
    {
        //Get Components
        weaponAgent = gameObject.transform.parent.parent.GetComponent<WeaponAgent>();
    }

    //Destroy Oneshot weapons after use
    protected override void Shoot ()
    {
        base.Shoot();
        if (triggerPulled)
        {
            weaponAgent.Unequip();
            weaponAgent.attachmentPoint.GetChild(0).gameObject.SetActive(true);
            weaponAgent.equippedWeapon = weaponAgent.attachmentPoint.GetChild(0).GetComponent<Weapon>();
            weaponAgent.UIWeaponPosition.GetChild(0).gameObject.SetActive(true);
            weaponAgent.equippedWeaponUI = weaponAgent.UIWeaponPosition.GetChild(0).GetComponent<Weapon>();
            //Change player's animation
            weaponAgent.anim.SetInteger("CurrentWeapon", (int)weaponAgent.equippedWeapon.animationType);
        }
       
    }

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(firingSound, transform.position, 1);
    }

}
