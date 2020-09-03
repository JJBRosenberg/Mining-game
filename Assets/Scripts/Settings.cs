using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    // Start is called before the first frame update
    [SerializeField] private Dropdown resolutionDropdown;

    [SerializeField] private Toggle fullscreenToggle;

    [SerializeField] private Slider volumeSlider;
    
    private Resolution[] resolutions;

    private int screenInt;

    private const string prefName = "optionvalue";
    private const string resName = "resolutionoption";

    private bool isFullscreen = false;


    private void Awake()
    {
        screenInt = PlayerPrefs.GetInt("togglestate");

        if (screenInt == 1)
        {
            isFullscreen = true;
            fullscreenToggle.isOn = true;
        }

        else
        {
            fullscreenToggle.isOn = false;
        }
        
        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
            {
                PlayerPrefs.SetInt(resName, resolutionDropdown.value);
                PlayerPrefs.Save();
            }
            ));
        
        
    }

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("MVolume"));
        
        
        
        resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        int currResolutionIndex = 0;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currResolutionIndex = i;
            }
            
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName, currResolutionIndex);
        resolutionDropdown.RefreshShownValue();
    }

    public void ToggleFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if (!isFullscreen)
        {
            PlayerPrefs.SetInt("togglestate", 0);
        }
        else
        {
            isFullscreen = true;
            PlayerPrefs.SetInt("togglestate", 1);
        }
        
    }

    public void SetVolume(float value)
    {
        PlayerPrefs.SetFloat("MVolume", value);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
}
