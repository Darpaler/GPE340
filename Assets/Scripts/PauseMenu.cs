using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    //Variables
    public GameObject pauseMenu;                    //The pause menu

    // Use this for initialization
    void Start () {

        //Turn off pause
        pauseMenu.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isPaused)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }
}
