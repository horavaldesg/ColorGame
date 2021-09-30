using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Options;

    public AudioMixer audioMixer;

    public Dropdown resDropdown;

    Resolution[] resolutions;

    void Start()
    {
        /*
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
        */
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    /*
    public void SetRes(int resIndex)
    {
        Resolution res = resolutions[resIndex];

        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    */
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void Play()
    {
        SceneManager.LoadScene("Test Level");
    }

    public void Title()
    {
        SceneManager.LoadScene("Mario UI");
    }

    public void OptionsMenu()
    {
        Menu.SetActive(false);
        Options.SetActive(true);
    }

    public void MainMenu()
    {
        Menu.SetActive(true);
        Options.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

