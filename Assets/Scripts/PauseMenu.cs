using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;

    public GameObject pauseMenu;


    public enum controlSchemes { Gamepad, Keyboard };

    public controlSchemes controlScheme;

    PlayerControls controls;


    private void Awake()
    {
        controls.Gameplay.Pause.performed += tgb => GamePause = true;
        controls.Gameplay.Pause.canceled += tgb => GamePause = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (GamePause)
        {
            Resume();

        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale=0f;
        GamePause = true;
    }

}
