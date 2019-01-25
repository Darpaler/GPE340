using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Pawn pawn;
    public Vector3 moveVector = new Vector3();
    public Transform testObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        Rotation();
	    Movement();
	}

    void Rotation()
    {
        Plane thePlane = new Plane(Vector3.up, pawn.tf.position);
        Ray theRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        thePlane.Raycast(theRay, out distance);

        Vector3 targetPoint = theRay.GetPoint(distance);
        //Temp: Move object to point
        testObject.position = targetPoint;

        pawn.RotateTowards(targetPoint);
    }

    void Movement()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        moveVector = pawn.tf.InverseTransformDirection(moveVector);
        moveVector = Vector3.ClampMagnitude(moveVector, 1.0f);
        pawn.Move(moveVector);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            pawn.isCrouching = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            pawn.isCrouching = false;
        }
    }

}
