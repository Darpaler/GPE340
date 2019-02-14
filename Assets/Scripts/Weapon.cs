using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Required Components
[RequireComponent(typeof(WeaponAgent))]

public class Weapon : MonoBehaviour {

    //Variables
    public enum WeaponAnimationType { None = 0, Handgun = 1, Rifle = 2 }
    public WeaponAnimationType animationType = WeaponAnimationType.None;
    public Transform RightHandIKTarget;
    public Transform LeftHandIKTarget;
    protected WeaponAgent agent;

    // Use this for initialization
    void Start () {
		//GetComponents
        agent = gameObject.GetComponent<WeaponAgent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
