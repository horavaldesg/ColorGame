using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    //Resolutions
    private const string RES_PREF = "resolution";

    [SerializeField]
    private Text resText;

    private Resolution[] resolutions;

    private int currentResIndex = 0;

    //Options
    public GameObject Menu;
    public GameObject Options;

    void Start()
    {
        resolutions = Screen.resolutions;

        currentResIndex = PlayerPrefs.GetInt(RES_PREF, 0);

    }

    //Resolution Cycling
    private void SetResText(Resolution resolution)
    {
        resText.text = resolution.width + "x" + resolution.height;
    }

    public void SetNextRes() 
    {
        currentResIndex = GetNextWrappedIndex(resolutions, currentResIndex);
        SetResText(resolutions[currentResIndex]);
    }
    public void SetPrevRes()
    {
        currentResIndex = GetPrevWrappedIndex(resolutions, currentResIndex);
        SetResText(resolutions[currentResIndex]);
    }


    //Resolution Index Wrap
    private int GetNextWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        return (currentIndex + 1) % collection.Count;
    }

    private int GetPrevWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        if ((currentIndex - 1) < 0) return collection.Count - 1;
        return (currentIndex - 1) % collection.Count;
    }

    //Apply Res
    private void SetandApplyRes(int newResIndex)
    {
        currentResIndex = newResIndex;
        ApplyCurrentRes();
    }

    private void ApplyCurrentRes()
    {
        ApplyRes(resolutions[currentResIndex]);
    }

    private void ApplyRes(Resolution resolution)
    {
        SetResText(resolution);

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RES_PREF, currentResIndex);
    }

    public void ApplyChanges()
    {
        SetandApplyRes(currentResIndex);
    }

    // Graphics Quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Fullscreen Toggle
    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    // Play and Back
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Title()
    {
        SceneManager.LoadScene("Horacio UI");
    }

    //Toggle Main Menu
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
    
    //Quit
    public void Quit()
    {
        Application.Quit();
    }
}

