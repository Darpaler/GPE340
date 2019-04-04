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
    public bool died = false;           //Weather the pawn is dead or not

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
        Pawn pawn = gameObject.GetComponent<Pawn>();
        //Subtract health
        health -= amount;
        
        //If they die
        if(health <= 0)
        {
            if(ragdoll != null)
            {
                //Activate Ragdoll
                ragdoll.ActivateRagdoll();
                if (weaponAgent != null)
                {
                    //Give the weapon a Rigidbody for gravity
                    weaponAgent.attachmentPoint.gameObject.AddComponent<Rigidbody>();

                    //Make sure it's not shooting
                    gameObject.BroadcastMessage("ReleaseTrigger", SendMessageOptions.DontRequireReceiver);
                }
                //Destroy the player
                if (pawn != null)
                {
                    pawn.controller.Die();
                }
                Destroy(gameObject, despawnTime);
            }
            else
            {
                //Destroy the player
                if (pawn != null)
                {
                    pawn.controller.Die();
                }
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
