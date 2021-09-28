using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropDownScript : MonoBehaviour
{
    TMP_Dropdown dropdown;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        if (gameController.controlScheme == GameController.controlSchemes.Keyboard)
        {
            dropdown.value = 0;
        }
        else if (gameController.controlScheme == GameController.controlSchemes.Gamepad)
        {
            dropdown.value = 1;
        }
        Debug.Log(dropdown.value);
    }

    // Update is called once per frame
    void Update()
    {
        //keyboard
        if(dropdown.value == 0)
        {
            gameController.controlScheme = GameController.controlSchemes.Keyboard;
        }
        //controller
        else if(dropdown.value == 1)
        {
            gameController.controlScheme = GameController.controlSchemes.Gamepad;

        }
    }
   
}
