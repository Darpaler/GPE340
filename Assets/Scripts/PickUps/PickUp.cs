using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{

    protected Transform tf;
    public float rotateSpeed;

	// Use this for initialization
	void Start ()
	{

	    tf = gameObject.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
		
        Spin();

	}

    protected void Spin()
    {
        tf.Rotate(0, rotateSpeed * Time.deltaTime, 0, relativeTo: Space.World);
    }

    public virtual void OnPickUp(GameObject target)
    {
        Debug.Log(target.name + " picked up " + gameObject.name);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pawn>() != null)
        {
            OnPickUp(other.gameObject);
        }
    }
}
