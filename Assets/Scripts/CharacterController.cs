using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Pawn pawn;
    public Vector3 moveVector = new Vector3();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    moveVector.x = Input.GetAxis("Horizontal");
	    moveVector.z = Input.GetAxis("Vertical");
        pawn.Move(moveVector);

	}
}
