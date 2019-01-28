using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Variables
    public Pawn pawn;                               //The Player's Pawn
    public Vector3 moveVector = new Vector3();      //Our Movement Input
    public Transform testObject;                    //Object For Testing Mouse Location

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Player Movement
        Rotation();
	    Movement();
	}

    void Rotation()
    {
        Plane thePlane = new Plane(Vector3.up, pawn.tf.position);       //Plane Under Where Our Pawn is
        Ray theRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Where the Mouse is Over the Plane

        //Get Where the Mouse Intersects
        float distance;
        thePlane.Raycast(theRay, out distance); 
        Vector3 targetPoint = theRay.GetPoint(distance);
        
        //Temp: Move object to point
        testObject.position = targetPoint;

        //Face That Point
        pawn.RotateTowards(targetPoint);
    }

    //Player Movement Input
    void Movement()
    {
        //Get Player Input
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        
        //Use Local Space
        moveVector = pawn.tf.InverseTransformDirection(moveVector);

        //Make Sure Controller and Keyboard Move the Same Speed
        moveVector = Vector3.ClampMagnitude(moveVector, 1.0f);

        //Check If Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            pawn.isCrouching = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            pawn.isCrouching = false;
        }

        //Move The Pawn
        pawn.Move(moveVector);
    }

}
