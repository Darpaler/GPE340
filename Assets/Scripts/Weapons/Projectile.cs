using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    //Variables
    public float damage{get; set;}  //How much damage the projectile should do
    public float bulletLifetime;    //How long the projectile lasts
    public Rigidbody rb;            //Rigidbody Component


    // Use this for initialization
    void Start () {

        //GetComponents
        rb = gameObject.GetComponent<Rigidbody>();

        //Set Lifetime
        Destroy(gameObject, bulletLifetime);

    }

    private void OnTriggerEnter(Collider other)
    {
        //If they have health, deal damage
        Health targetHP = other.gameObject.GetComponent<Health>();
        if (targetHP != null)
        {
            targetHP.TakeDamage(damage);
        }

        //If we're not hitting a pickup object, then destroy the bullet
        if(other.gameObject.GetComponent<PickUp>() == null)
        {
            Destroy(gameObject);
        }
    }
}
