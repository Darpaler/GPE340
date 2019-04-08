using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : PawnController {

    //Variables
    private Pawn pawn;              //The Pawn Component
    private NavMeshAgent agent;     //The NavMesh Component
    private Health hp;              //The Health Component
    public float targetDistance;    //Distance from the AI to the player to stop at

	// Use this for initialization
	void Start ()
	{
        //Get Components
	    pawn = GetComponent<Pawn>();
	    agent = GetComponent<NavMeshAgent>();
        hp = GetComponent<Health>();

        //Set GameManager
        GameManager.instance.enemies.Add(this);

        //Set Pawn
        pawn.controller = this;

	}

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPaused)
            return;
        //If we died
        if (hp.health <= 0)
        {
            //Do nothing
            return;
        }

        //Chase Player
        if(GameManager.instance.player.pawn != null)
        {
            agent.SetDestination(GameManager.instance.player.pawn.tf.position);

            //Always Face Player
            pawn.RotateTowards(GameManager.instance.player.pawn.tf.position);

            //If we're not too close to the player
            if (Vector3.Distance(GameManager.instance.player.pawn.tf.position, pawn.tf.position) > targetDistance + 1)
            {
                //Get close to them
                MoveWithRootMotion(true);
                //Not close enough to shoot yet
                pawn.gameObject.BroadcastMessage("ReleaseTrigger", SendMessageOptions.DontRequireReceiver);
            }
            //If we're too close
            else if (Vector3.Distance(GameManager.instance.player.pawn.tf.position, pawn.tf.position) < targetDistance - 1)
            {
                //Run away
                MoveWithRootMotion(false);
                //We're close enough to shoot now
                pawn.gameObject.BroadcastMessage("PullTrigger", SendMessageOptions.DontRequireReceiver);
            }
            //If we're at the target distance
            else
            {
                //Don't move
                pawn.anim.SetFloat("Horizontal", 0);
                pawn.anim.SetFloat("Vertical", 0);
                //We're close enough to shoot
                pawn.gameObject.BroadcastMessage("PullTrigger", SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            //Don't move
            pawn.anim.SetFloat("Horizontal", 0);
            pawn.anim.SetFloat("Vertical", 0);
            pawn.gameObject.BroadcastMessage("ReleaseTrigger", SendMessageOptions.DontRequireReceiver);
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

    public override void Die()
    {
        GameManager.instance.enemies.Remove(this);
        GameManager.instance.playerScore += 1;
    }

}
