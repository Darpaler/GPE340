using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour {

    //Variables
    public Transform targetObjectTransform;
    public Vector3 offset;

    private Transform tf;




	// Use this for initialization
	void Start ()
	{

	    tf = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update ()
	{

	    tf.position = targetObjectTransform.position + offset;
        tf.LookAt(targetObjectTransform.position);

	}
}
