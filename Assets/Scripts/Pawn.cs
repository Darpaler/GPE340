using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]

public class Pawn : MonoBehaviour
{

    //Variables
    [Header("Components")]
    [SerializeField]
    private Transform tf;                        //Transform Component
    public Transform Transform
    {get{return tf;}private set{tf = value;}}
    [SerializeField]
    private Animator anim;                      //Animator Component
    [SerializeField]
    private CapsuleCollider capsuleCollider;    //CapsuleCollider Components

    [Header("Movement Settings")]
    [SerializeField, Range(0f, 25f), Tooltip("The speed the player moves.")]
    public float moveSpeed;                     //Player's Movement Speed
    [SerializeField, Range(0f, 500f), Tooltip("The speed the player turns in degrees/second.")]
    public float turnSpeed;                     //Player's Turn Speed
    [Header("Crouch Settings")]
    [SerializeField, Tooltip("If the player is holding the crouch button.")]
    public bool isCrouching;                    //Is The Player Crouching
    [SerializeField, Tooltip("The center of the player's standing collider.")]
    public Vector3 normalColliderCenter;        //The Center of the Player's Standing Collider
    [SerializeField, Range(0f, 25f), Tooltip("The height of the player's standing collider.")]
    public float normalColliderHeight;          //The Height of The Player's Standing Collider
    [SerializeField, Tooltip("The center of the player's crouching collider.")]
    public Vector3 crouchColliderCenter;        //The Center of The Player's Crouching Collider
    [SerializeField, Range(0f, 25f), Tooltip("The height of the player's crouching collider.")]
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
    /// <summary>
    /// Sets the animator's Vertical, Horizontal, and Crouch variables, multiplied by the pawn's move speed.
    /// </summary>
    /// <param name="direction">The direction the player is moving in</param>
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
    /// <summary>
    /// Rotates the pawn towards a target point
    /// </summary>
    /// <param name="targetPoint">The target that the pawn will rotate towards</param>
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
