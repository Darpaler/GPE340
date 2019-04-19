using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionTest : MonoBehaviour
{
    [Header("Audio Settings")]
    public Slider masterVolumeSlider;               //Master Volume Slider
    public Slider musicVolumeSlider;                //Music Volume Slider
    public Slider sfxVolumeSlider;                  //SFX Volume Slider

    [Header("Video Settings")]
    public Dropdown resDropdown;                    //Resolution Dropdown
    public Toggle fullscreenToggle;
    public Dropdown qualityDropdown;                //Quality Dropdown
    List<string> resolutions = new List<string>();  //List of Resolutions
    List<string> qualities = new List<string>();    //List of Qualities

    [Header("Menu Settings")]
    public Button applyButton;                      //Apply Changes Button

    // Use this for initialization
    void Awake ()
	{
        //Clear Dropdowns
        resDropdown.ClearOptions();
        qualityDropdown.ClearOptions();

        //Set Lists
        for (int index = 0; index < Screen.resolutions.Length; index++)
        {
            resolutions.Add(string.Format("{0} x {1}", Screen.resolutions[index].width, Screen.resolutions[index].height));
        }
        resDropdown.AddOptions(resolutions);

        qualities = new List<string>(QualitySettings.names);
        qualityDropdown.AddOptions(qualities);

	}

    void OnEnable()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("Master Volume", masterVolumeSlider.maxValue);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("Music Volume", musicVolumeSlider.maxValue);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFX Volume", sfxVolumeSlider.maxValue);
        fullscreenToggle.isOn = Screen.fullScreen;
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        applyButton.interactable = false;
    }

    public void Apply()
    {
        PlayerPrefs.SetFloat("Master Volume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("Music Volume", musicVolumeSlider.maxValue);
        PlayerPrefs.SetFloat("SFX Volume", sfxVolumeSlider.maxValue);
        string[] r = resDropdown.options[resDropdown.value].text.Split('x');
        Screen.SetResolution(int.Parse(r[0].Trim()), int.Parse(r[1].Trim()), fullscreenToggle.isOn);
        Debug.Log(r[0].Trim() + " x " + r[1].Trim());
        Debug.Log(Screen.currentResolution);
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        applyButton.interactable = false;
    }

    // Update is called once per frame
    void Update () {
	}

    public void enableApply()
    {
        if (!applyButton.interactable) { applyButton.interactable = true; }
    }

}
