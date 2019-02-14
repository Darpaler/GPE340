using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private float health;
    public float maxHealth;

	// Use this for initialization
	void Start ()
	{
	    health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float amount, bool canGoOverMax = false)
    {
        health += amount;
        if (!canGoOverMax)
        {
            health = Mathf.Clamp(health, 0, maxHealth);
        }
    }
}
