using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    //Variable
    public enum WeaponAnimationType { None = 0, Handgun = 1, Rifle = 2 }
    [Header("Weapon Type")]
    public WeaponAnimationType animationType = WeaponAnimationType.None;
    public float damage;
    [Header("IK Settings")]
    public Transform RightHandIKTarget;
    public Transform LeftHandIKTarget;

    // Use this for initialization
    void Start () {
		//GetComponents
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
