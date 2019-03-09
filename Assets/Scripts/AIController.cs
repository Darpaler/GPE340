using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {

    //Variables
    private Pawn pawn;
    private NavMeshAgent agent;
    public float targetDistance;    //Distance from the AI to the player to stop at

	// Use this for initialization
	void Start ()
	{
        //Get Components
	    pawn = GetComponent<Pawn>();
	    agent = GetComponent<NavMeshAgent>();

        //Set GameManager
	    GameManager.instance.enemy = this;

	}

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(GameManager.instance.player.pawn.tf.position);

        pawn.RotateTowards(GameManager.instance.player.pawn.tf.position);

        //If we're not too close to the player
        if (Vector3.Distance(GameManager.instance.player.pawn.tf.position, pawn.tf.position) > targetDistance + 1)
        {
            MoveWithRootMotion(true);
            pawn.gameObject.BroadcastMessage("ReleaseTrigger", SendMessageOptions.DontRequireReceiver);
            Debug.Log("Release");
        }
        //If we're too close run away
        else if (Vector3.Distance(GameManager.instance.player.pawn.tf.position, pawn.tf.position) < targetDistance - 1)
        {
            MoveWithRootMotion(false);
            pawn.gameObject.BroadcastMessage("PullTrigger", SendMessageOptions.DontRequireReceiver);
            Debug.Log("Pull");
        }
        //If we're at the target distance, don't move at all
        else
        {
            pawn.anim.SetFloat("Horizontal", 0);
            pawn.anim.SetFloat("Vertical", 0);
            pawn.gameObject.BroadcastMessage("PullTrigger", SendMessageOptions.DontRequireReceiver);
            Debug.Log("Pull");
        }

    }

    void MoveWithRootMotion(bool runTowards)
    {
        //Get desired velocity from NavMesh Agent
        Vector3 desiredVelocity = agent.desiredVelocity * pawn.moveSpeed;
       
        desiredVelocity = pawn.tf.InverseTransformDirection(desiredVelocity);

        //Run towards the player
        if (runTowards)
        {
            pawn.anim.SetFloat("Horizontal", desiredVelocity.x);
            pawn.anim.SetFloat("Vertical", desiredVelocity.z);
        }
        //Run away from the player
        else
        {
            pawn.anim.SetFloat("Horizontal", -desiredVelocity.x);
            pawn.anim.SetFloat("Vertical", -desiredVelocity.z);
        }
    }

    private void OnAnimatorMove()
    {
        //Make sure we don't double our speed by setting our NavMesh Agent velocity to our root-motion-determined velocity
        agent.velocity = pawn.anim.velocity;
    }


}
