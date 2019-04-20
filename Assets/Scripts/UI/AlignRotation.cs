using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignRotation : MonoBehaviour
{
    [SerializeField, Tooltip("The Transform to match rotations with")]
    private Transform target;
    [SerializeField, Tooltip("The speed to match the target's rotation")]
    private float speed = 5f;

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, speed * Time.deltaTime);
    }
}