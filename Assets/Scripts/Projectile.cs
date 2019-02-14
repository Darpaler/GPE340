using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    //Variables
    public float damage{get; set;}
    public float bulletLifetime;
    public Rigidbody rb;


    // Use this for initialization
    void Start () {

        //GetComponents
        rb = gameObject.GetComponent<Rigidbody>();

        //Set Lifetime
        Destroy(gameObject, bulletLifetime);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Health targetHP = other.gameObject.GetComponent<Health>();
        if (targetHP != null)
        {
            targetHP.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
