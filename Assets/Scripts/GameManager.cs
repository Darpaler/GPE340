using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }
    public CharacterController player;
    public AIController enemy;
    public bool isPaused;

    //TODO: Track previous player and enemy weapons

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TogglePause()
    {
        if(isPaused)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    { 
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }


}
