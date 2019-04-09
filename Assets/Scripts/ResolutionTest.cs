using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionTest : MonoBehaviour
{

    public Dropdown resDropdown;

	// Use this for initialization
	void Start ()
	{

	    resDropdown = GetComponent<Dropdown>();
        resDropdown.ClearOptions();
        List<string> resolutioList = new List<string>();

        /*
	    for (int i = 0; i < Screen.resolutions.Length; i++)
	    {
            resolutioList.Add(Screen.resolutions[i].width + " x " + Screen.resolutions[i].height);
	    }
        */

        resolutioList = new List<string>(QualitySettings.names);

        resDropdown.AddOptions(resolutioList);

        QualitySettings.SetQualityLevel(resDropdown.value);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
