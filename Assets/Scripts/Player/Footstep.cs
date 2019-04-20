using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {

    [SerializeField, Tooltip("The audio source to play through")]
    private AudioSource audioSource;
    [SerializeField, Tooltip("The footstep sound")]
    private AudioClip footstepClip;

    private void AnimationEventFootstep()
    {
        audioSource.PlayOneShot(footstepClip);
    }
}
