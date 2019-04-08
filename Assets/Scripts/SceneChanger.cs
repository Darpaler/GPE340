using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    //Start the Main Menu
    public void RunMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
        //Unpause if paused
        GameManager.instance.UnPause();

        //Reset Score
        GameManager.instance.playerScore = 0;
    }

    //Start the Game
    public void RunGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Quit
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    //Start the Win Screen
    public void RunWin()
    {
        SceneManager.LoadScene("Win");
    }

}
