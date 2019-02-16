using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    //Variables
    Camera m_Camera;    //Main Camera

    void Start()
    {
        //Get Main Camera
        m_Camera = Camera.main;
    }

    void Update()
    {
        //Face the camera
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                         m_Camera.transform.rotation * Vector3.up);
    }
}
