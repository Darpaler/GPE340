using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Variables
    [SerializeField, Tooltip("The pawn that the player controls.")]
    public Pawn pawn;                               //The Player's Pawn
    [SerializeField, Tooltip ("The player's movement input.")]
    private Vector3 moveVector = new Vector3();     //Our Movement Input
    [SerializeField, Tooltip("Object for testing where the mouse is.")]
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
        Shoot();
	}

    /// <summary>
    /// Causes the pawn to face the mouse
    /// </summary>
    void Rotation()
    {
        Plane thePlane = new Plane(Vector3.up, pawn.Transform.position);       //Plane Under Where Our Pawn is
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
    /// <summary>
    /// Gets the players movement input and sends it to the pawn
    /// </summary>
    void Movement()
    {
        //Get Player Input
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        
        //Use Local Space
        moveVector = pawn.Transform.InverseTransformDirection(moveVector);

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

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pawn.gameObject.BroadcastMessage("PullTrigger", SendMessageOptions.DontRequireReceiver);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pawn.gameObject.BroadcastMessage("ReleaseTrigger", SendMessageOptions.DontRequireReceiver);
        }

    }

}
