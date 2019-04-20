using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ResolutionTest : MonoBehaviour
{
    [Header("Audio Settings")]
    public Slider masterVolumeSlider;               //Master Volume Slider
    public Slider musicVolumeSlider;                //Music Volume Slider
    public Slider sfxVolumeSlider;                  //SFX Volume Slider
    [SerializeField, Tooltip("The master audio mixer")]
    private AudioMixer audioMixer;
    [SerializeField, Tooltip("The slider value vs decibel volume curve")]
    private AnimationCurve volumeVsDecibels;

    [Header("Video Settings")]
    public Dropdown resDropdown;                    //Resolution Dropdown
    public Toggle fullscreenToggle;                 //Toggles fullscreen
    public Dropdown qualityDropdown;                //Quality Dropdown
    List<string> resolutions = new List<string>();  //List of Resolutions
    List<string> qualities = new List<string>();    //List of Qualities

    [Header("Menu Settings")]
    public Button applyButton;                      //Apply Changes Button
    private Scene scene;                            //The current scene

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

    void Start()
    {
        //Get Scene
        scene = SceneManager.GetActiveScene();

        //Turn Off Options Screen
        gameObject.SetActive(false);
        enabled = false;

        //Set Music
        audioMixer.SetFloat("MainVolume", volumeVsDecibels.Evaluate(masterVolumeSlider.value));
        audioMixer.SetFloat("MusicVolume", volumeVsDecibels.Evaluate(musicVolumeSlider.value));
        audioMixer.SetFloat("SFXVolume", volumeVsDecibels.Evaluate(sfxVolumeSlider.value));
    }

    void Update()
    {
        //If game is unpaused, disable the option screen
        if ((!GameManager.instance.isPaused) && scene.name == "SampleScene" && (gameObject.activeSelf))
        {
            gameObject.SetActive(false);
            enabled = false;
        }
    }
    void OnEnable()
    {
        //Get Audio
        masterVolumeSlider.value = PlayerPrefs.GetFloat("Master Volume", masterVolumeSlider.maxValue);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("Music Volume", musicVolumeSlider.maxValue);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFX Volume", sfxVolumeSlider.maxValue);
        audioMixer.SetFloat("MainVolume", volumeVsDecibels.Evaluate(masterVolumeSlider.value));
        audioMixer.SetFloat("MusicVolume", volumeVsDecibels.Evaluate(musicVolumeSlider.value));
        audioMixer.SetFloat("SFXVolume", volumeVsDecibels.Evaluate(sfxVolumeSlider.value));
        //Get Video
        fullscreenToggle.isOn = Screen.fullScreen;
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        //Disable apply
        applyButton.interactable = false;
    }

    public void Apply()
    {
        //Set Audio
        PlayerPrefs.SetFloat("Master Volume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("Music Volume", musicVolumeSlider.maxValue);
        PlayerPrefs.SetFloat("SFX Volume", sfxVolumeSlider.maxValue);
        audioMixer.SetFloat("MainVolume", volumeVsDecibels.Evaluate(masterVolumeSlider.value));
        audioMixer.SetFloat("MusicVolume", volumeVsDecibels.Evaluate(musicVolumeSlider.value));
        audioMixer.SetFloat("SFXVolume", volumeVsDecibels.Evaluate(sfxVolumeSlider.value));
        //Set Video
        string[] r = resDropdown.options[resDropdown.value].text.Split('x');
        Screen.SetResolution(int.Parse(r[0].Trim()), int.Parse(r[1].Trim()), fullscreenToggle.isOn);
        Debug.Log(r[0].Trim() + " x " + r[1].Trim());
        Debug.Log(Screen.currentResolution);
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        //Disable apply
        applyButton.interactable = false;
    }

    public void enableApply()
    {
        //Enable apply when something changes
        if (!applyButton.interactable) { applyButton.interactable = true; }
    }

    public void ToggleOptions()
    {
        //Turn options screen on/off
        gameObject.SetActive(!gameObject.activeSelf);
        enabled = !enabled;
    }
}
