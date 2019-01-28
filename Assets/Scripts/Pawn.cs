using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{

    //Variables
    public Transform tf;                        //Transform Component
    private Animator anim;                      //Animator Component
    public float moveSpeed;                     //Player's Movement Speed
    public float turnSpeed;                     //Player's Turn Speed
    public bool isCrouching;                    //Is The Player Crouching
    public CapsuleCollider capsuleCollider;     //CapsuleCollider Components
    public Vector3 normalColliderCenter;        //The Center of The Player's Standing Collider
    public float normalColliderHeight;          //The Height of The Player's Standing Collider
    public Vector3 crouchColliderCenter;        //The Center of The Player's Crouching Collider
    public float crouchColliderHeight;          //The Height of The Player's Crouching Collider


	// Use this for initialization
	void Start ()
	{
        //Get Components
	    tf = GetComponent<Transform>();
	    anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Player Movement
    public void Move(Vector3 direction)
    {
        //Tell The Animator How The Player is Moving
        anim.SetFloat("Vertical", direction.z * moveSpeed);     //Foward and Backward Movement
        anim.SetFloat("Horizontal", direction.x * moveSpeed);   //Left and Right Movement
        anim.SetBool("IsCrouching", isCrouching);               //Crouch and Uncrouch Movement

        //When Crouching
        if (isCrouching)
        {
            //Make the Collider Smaller
            capsuleCollider.center = crouchColliderCenter;
            capsuleCollider.height = crouchColliderHeight;
        }
        else
        {
            //Go Back to the Standing Collider
            capsuleCollider.center = normalColliderCenter;
            capsuleCollider.height = normalColliderHeight;
        }
    }

    //Player Rotation
    public void RotateTowards(Vector3 targetPoint)
    {
        //Find the Difference Between the Pawn and What We Want to Look At
        Vector3 vectorToLookDown = targetPoint - tf.position;
        //Get the Rotation
        Quaternion lookRotation = Quaternion.LookRotation(vectorToLookDown, tf.up);
        //Look There
        tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

}
