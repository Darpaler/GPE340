using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour {

    //Variables
    public Transform targetObjectTransform; //Target Object
    public Vector3 offset;                  //Offest

    private Transform tf;                   //Transform Component




	// Use this for initialization
	void Start ()
	{
        //Get Components
	    tf = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update ()
	{
        //Follow The Target Object at a Specific Offset
	    tf.position = targetObjectTransform.position + offset;
        //Face the Target Object
        tf.LookAt(targetObjectTransform.position);
	}
}
