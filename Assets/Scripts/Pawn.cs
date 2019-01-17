using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{

    public Transform tf;
    private Animator anim;


	// Use this for initialization
	void Start ()
	{

	    tf = GetComponent<Transform>();
	    anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector3 direction)
    {
        anim.SetFloat("Vertical", direction.z);
        anim.SetFloat("Horizontal", direction.x);
    }
}
