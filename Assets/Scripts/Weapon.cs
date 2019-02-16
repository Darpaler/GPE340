using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    //Variable
    public enum WeaponAnimationType { None = 0, Handgun = 1, Rifle = 2 }    //Weapon types
    [Header("Weapon Type")]
    public WeaponAnimationType animationType = WeaponAnimationType.None;    //Current weapon type
    public float damage;                                                    //How much damage a weapon does
    [Header("IK Settings")]
    public Transform RightHandIKTarget;                                     //Where the right hand should go
    public Transform LeftHandIKTarget;                                      //Where the left hand should go

}
