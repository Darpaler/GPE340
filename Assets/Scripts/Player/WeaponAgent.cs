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
        equippedWeapon.gameObject.layer = gameObject.layer;
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

    protected virtual void OnAnimatorIK()
    {
        if (!equippedWeapon)
            return;
        if (equippedWeapon.RightHandIKTarget)
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, equippedWeapon.RightHandIKTarget.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            anim.SetIKRotation(AvatarIKGoal.RightHand, equippedWeapon.RightHandIKTarget.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
        }
        if (equippedWeapon.LeftHandIKTarget)
        {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, equippedWeapon.LeftHandIKTarget.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, equippedWeapon.LeftHandIKTarget.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
        }
    }
}
