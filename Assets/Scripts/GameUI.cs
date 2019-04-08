using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    //Variables
    public Text livesUI;                            //The Lives display on the UI
    public Transform uiWeaponPosition;              //The UI weapon position

    // Update is called once per frame
    void Start()
    {
        //Set UI Weapon Position
        GameManager.instance.uiWeaponPosition = uiWeaponPosition;
    }

    void Update () {
        //Upadate Player Lives
        if (GameManager.instance.player != null) { livesUI.text = "x" + GameManager.instance.player.lives; }
    }
}
