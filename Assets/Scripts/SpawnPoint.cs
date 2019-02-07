using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    //Variables
    public float respawnTime;                                                 //How long it takes to respawn
    public GameObject objectToSpawn;                                          //Object that is respawning
    private GameObject spawnedObject;                                         //The object that we spawned
    private float timeUntilNextRespawn;                                       //Time until it respawns again
    private Transform tf;                                                     //Where it respawns


    private void Awake()
    {
        tf = GetComponent<Transform>();                                       
    }
	// Use this for initialization
	void Start ()
	{

	    Spawn();

	}
	
	// Update is called once per frame
	void Update () {
		
	    //Check if they are still there
        if (spawnedObject != null) return;

        //If not, count down
	    timeUntilNextRespawn -= Time.deltaTime;

        //When timer hits 0, respawn
        if(timeUntilNextRespawn <= 0) Spawn();
	}

    public void Spawn()
    {
        //Spawn object
        spawnedObject = Instantiate(objectToSpawn, tf.position, tf.rotation);

        //Reset timer
        timeUntilNextRespawn = respawnTime;
    }

}
