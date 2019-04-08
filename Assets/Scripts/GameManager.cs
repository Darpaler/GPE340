using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }
    public CharacterController player;
    public List<AIController> enemies;
    public bool isPaused;                           //If the game is paused
    public Camera main;                             //The Main Camera
    public FollowGameObject mainFollow;             //Main Camera Follow Game Object Component
    public Transform uiWeaponPosition;              //The UI weapon position
    public int playerScore = 0;                     //The player's score
    public int winCondition;                        //Points needed to win

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
        DontDestroyOnLoad(instance);
    }
	
	// Update is called once per frame
	void Update () {
        if (player == null) { player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>(); }
        if (main == null)
        {
            main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            mainFollow = main.GetComponent<FollowGameObject>();
        }
        else if (mainFollow.targetObjectTransform == null && player != null)
        {
            if(player.pawn != null) { mainFollow.targetObjectTransform = player.pawn.tf; }
        }

        //Check for win
        if(playerScore >= winCondition)
        {
            GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>().RunWin();
        }

	}

    //Swap between Pause and UnPause
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
        //Pause the game
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void UnPause()
    {
        //UnPause the game
        Time.timeScale = 1f;
        isPaused = false;
    }
}
