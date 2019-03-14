using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    //Variables
    protected Transform tf;     //Transform Component
    public float rotateSpeed;   //Rotation speed

	// Use this for initialization
	void Start ()
	{
        //Get Components
	    tf = gameObject.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

	    if (GameManager.instance.isPaused)
	        return;
        //Spin the pickup
        Spin();

	}

    //Spin the pickup
    protected void Spin()
    {
        //Rotate using the rotate speed
        tf.Rotate(0, rotateSpeed * Time.deltaTime, 0, relativeTo: Space.World);
    }

    //On Pickup
    public virtual void OnPickUp(GameObject target)
    {
        //Print who picked up what
        Debug.Log(target.name + " picked up " + gameObject.name);

        //Destroy the object
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If it's not a player, don't pick it up
        if (other.gameObject.GetComponent<Pawn>() != null)
        {
            OnPickUp(other.gameObject);
        }
    }
}
