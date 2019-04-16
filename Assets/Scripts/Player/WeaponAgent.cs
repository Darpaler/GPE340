using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WeaponAgent : MonoBehaviour {

    //Variables
    public Weapon defaultWeapon;       //Starting weapon
    public Transform attachmentPoint;  //Where they hold the gun
    public Weapon equippedWeapon;      //Currently equiped weapon
    public Animator anim;             //Animator component
    public Transform UIWeaponPosition; //Where to show the weapon on the UI
    public Weapon equippedWeaponUI;   //The weapon shown on the UI
    public Pawn pawn;

    // Use this for initialization
    void Start () {

        //Get Components
        anim = gameObject.GetComponent<Animator>();
        pawn = GetComponent<Pawn>();

        //Equip Default
        EquipWeapon(defaultWeapon);

    }
	
    //Equip Weapon
    public void EquipWeapon(Weapon weapon)
    {
        //Create Weapon
        equippedWeapon = Instantiate(weapon) as Weapon;
        //Set it to player's layer
        equippedWeapon.gameObject.layer = gameObject.layer;
        //Make it a child of player
        equippedWeapon.transform.SetParent(attachmentPoint);
        //Set weapon position
        equippedWeapon.transform.localPosition = weapon.transform.localPosition;
        //Set weapon rotation
        equippedWeapon.transform.localRotation = weapon.transform.localRotation;
        //Change player's animation
        anim.SetInteger("CurrentWeapon", (int) equippedWeapon.animationType);
        //Set UI Weapon
        if (UIWeaponPosition != null)
        {
            equippedWeaponUI = Instantiate(weapon, UIWeaponPosition) as Weapon;
            equippedWeaponUI.enabled = false;
            equippedWeaponUI.transform.localPosition = Vector3.zero;
        }
    }

    /// 
    /// Unequip the equipped weapon, if there is one
    /// 
    public void Unequip()
    {
        //If they have a weapon
        if (equippedWeapon)
        {
            //destroy it
            Destroy(equippedWeapon.gameObject);
            //Set their weapon to null
            equippedWeapon = null;
            //Set the player's animation
            anim.SetInteger("CurrentWeapon", 0);
            //Set UI Weapon
            if (UIWeaponPosition != null)
            {
                Destroy(equippedWeaponUI.gameObject);
            }
        }
    }

    //Set IK
    protected virtual void OnAnimatorIK()
    {
        //If they don't have a weapon, don't use IK
        if (!equippedWeapon)
            return;

        //Set right hand position and rotation
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

        //Set left hand position and rotation
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
