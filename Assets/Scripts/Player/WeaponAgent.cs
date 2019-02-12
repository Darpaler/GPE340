using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WeaponAgent : MonoBehaviour {

    //Variables
    public Weapon defaultWeapon;        //Starting weapon
    public Transform attachmentPoint;   //Where they hold the gun
    private Weapon equippedWeapon;      //Currently equiped weapon
    private Animator anim;              //Animator component

    // Use this for initialization
    void Start () {

        //Get Components
        anim = gameObject.GetComponent<Animator>();

        EquipWeapon(defaultWeapon);
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    public void EquipWeapon(Weapon weapon)
    {
        equippedWeapon = Instantiate(weapon) as Weapon;
        equippedWeapon.transform.SetParent(attachmentPoint);
        equippedWeapon.transform.localPosition = weapon.transform.localPosition;
        equippedWeapon.transform.localRotation = weapon.transform.localRotation;
        anim.SetInteger("CurrentWeapon", (int) equippedWeapon.animationType);
    }

    /// 
    /// Unequip the equipped weapon, if there is one
    /// 
    public void Unequip()
    {
        if (equippedWeapon)
        {
            Destroy(equippedWeapon.gameObject);
            equippedWeapon = null;
            anim.SetInteger("CurrentWeapon", 0);
        }
    }
}
