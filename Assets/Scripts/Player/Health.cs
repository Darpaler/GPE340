using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    //Variables
    public float health { get; set; }   //Current health
    public float maxHealth;             //Max health
    public Slider healthBar;            //UI health
    public float despawnTime;           //Time till dead player despawns 
    private RagdollControls ragdoll;    //Ragdoll Controls component
    private WeaponAgent weaponAgent;    //Weapon Agent component

	// Use this for initialization
	void Start ()
	{
        //Get Components
        healthBar = gameObject.GetComponentInChildren<Slider>();
        ragdoll = gameObject.GetComponent<RagdollControls>();
        weaponAgent = gameObject.GetComponent<WeaponAgent>();

        //Set health bar max
        healthBar.maxValue = maxHealth;

        //Set health to max
	    health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

        //Display Health
        healthBar.value = health;

	}

    //Take damage
    public void TakeDamage(float amount)
    {
        //Subtract health
        health -= amount;
        
        //If they die
        if(health <= 0)
        {
            if(ragdoll != null)
            {
                //Activate Ragdoll
                ragdoll.ActivateRagdoll();
                if(weaponAgent != null)
                {
                    weaponAgent.attachmentPoint.gameObject.AddComponent<Rigidbody>();
                }
                //Destroy the player
                Destroy(gameObject, despawnTime);
            }
            else
            {
                //Destroy the player
                Destroy(gameObject);
            }
        }
    }

    //Heal and Over Heal
    public void Heal(float amount, bool canGoOverMax = false)
    {
        //Add health
        health += amount;

        //If they can't over heal
        if (!canGoOverMax)
        {
            //Limit their health at max
            health = Mathf.Clamp(health, 0, maxHealth);
        }
    }
}
