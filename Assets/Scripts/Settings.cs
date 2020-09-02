using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    public Dropdown resolutionDropdown;
    
    private Resolution[] resolutions;
    
    private void Start()
    {
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
        resolutionDropdown.value = currResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void ToggleFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("Volume", value);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
}
