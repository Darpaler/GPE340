using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollControls : MonoBehaviour
{

    //Variables
    public GameObject objectToApplyRagdoll;

    //Turn off to ragdoll
    public Collider mainCollider;
    public Animator anim;
    public Rigidbody mainRigidbody;
    public NavMeshAgent agent;

    //Turn on to ragdoll
    public List<Rigidbody> partRigidbodies;
    public List<Collider> partColliders;

	// Use this for initialization
	void Start ()
	{
        //Get Components
        mainCollider = objectToApplyRagdoll.GetComponent<Collider>();
        anim = objectToApplyRagdoll.GetComponent<Animator>();
	    mainRigidbody = objectToApplyRagdoll.GetComponent<Rigidbody>();
	    agent = objectToApplyRagdoll.GetComponent<NavMeshAgent>();
	    objectToApplyRagdoll = gameObject;

        partRigidbodies = new List<Rigidbody>(objectToApplyRagdoll.GetComponentsInChildren<Rigidbody>());
        partColliders = new List<Collider>(objectToApplyRagdoll.GetComponentsInChildren<Collider>());

        //Deactivate ragdoll by default
	    DeactivateRagdoll();

	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.P))
	    {
	        ActivateRagdoll();

	    }

	    if (Input.GetKeyDown(KeyCode.O))
	    {
	        DeactivateRagdoll();
	    }

	}

    public void ActivateRagdoll()
    {
        //Turn on all the child rigidbodies
        foreach (Rigidbody rb in partRigidbodies)
        {
            rb.isKinematic = false;
        }

        //Turn on all the child colliders
        foreach (Collider col in partColliders)
        {
            col.enabled = true;
        }

        //Turn off the main stuff
        mainRigidbody.isKinematic = true;
        mainCollider.enabled = false;
        anim.enabled = false;
        agent.enabled = false;
    }
    public void DeactivateRagdoll()
    {
        //Turn off all the child rigidbodies
        foreach (Rigidbody rb in partRigidbodies)
        {
            rb.isKinematic = true;
        }

        //Turn off all the child colliders
        foreach (Collider col in partColliders)
        {
            col.enabled = false;
        }

        //Turn on the main stuff
        mainRigidbody.isKinematic = false;
        mainCollider.enabled = true;
        anim.enabled = true;
        agent.enabled = true;
    }
}
