using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    //Variables
    public float health { get; set; }   //Current health
    public float maxHealth;             //Max health
    public Slider healthBar;            //UI health

	// Use this for initialization
	void Start ()
	{
        //Get Components
        healthBar = gameObject.GetComponentInChildren<Slider>();

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
            //Destroy the player
            Destroy(gameObject);
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
