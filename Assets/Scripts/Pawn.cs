using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{

    public Transform tf;
    private Animator anim;
    public float moveSpeed;
    public float turnSpeed;
    public bool isCrouching;
    public CapsuleCollider capsuleCollider;
    public Vector3 normalColliderCenter;
    public float normalColliderHeight;
    public Vector3 crouchColliderCenter;
    public float crouchColliderHeight;


	// Use this for initialization
	void Start ()
	{

	    tf = GetComponent<Transform>();
	    anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector3 direction)
    {
        anim.SetFloat("Vertical", direction.z * moveSpeed);
        anim.SetFloat("Horizontal", direction.x * moveSpeed);
        anim.SetBool("IsCrouching", isCrouching);
        if (isCrouching)
        {
            capsuleCollider.center = crouchColliderCenter;
            capsuleCollider.height = crouchColliderHeight;
        }
        else
        {
            capsuleCollider.center = normalColliderCenter;
            capsuleCollider.height = normalColliderHeight;
        }
    }

    public void RotateTowards(Vector3 targetPoint)
    {
        Vector3 vectorToLookDown = targetPoint - tf.position;
        Quaternion lookRotation = Quaternion.LookRotation(vectorToLookDown, tf.up);
        tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

}
