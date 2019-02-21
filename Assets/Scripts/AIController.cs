using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {

    //Variables
    public Pawn playerPawn;
    private Pawn pawn;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start ()
	{
        //Get Components
	    pawn = GetComponent<Pawn>();
	    agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    agent.SetDestination(playerPawn.tf.position);

	    MoveWithRootMotion();
	}

    void MoveWithRootMotion()
    {
        //Get desired velocity from NavMesh Agent
        Vector3 desiredVelocity = agent.desiredVelocity * pawn.moveSpeed;
       
        desiredVelocity = pawn.tf.InverseTransformDirection(desiredVelocity);

        pawn.anim.SetFloat("Horizontal", desiredVelocity.x);
        pawn.anim.SetFloat("Vertical", desiredVelocity.z);


    }

    private void OnAnimatorMove()
    {
        //Make sure we don't double our speed by setting our NavMesh Agent velocity to our root-motion-determined velocity
        agent.velocity = pawn.anim.velocity;
    }


}
