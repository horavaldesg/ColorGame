using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    public GameObject[] menus;
    public InputHandler ctScheme;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        i = -1;

        //if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
        //{
        //    i = 0;
        //}
        //else if (ctScheme.controlScheme == InputHandler.controlSchemes.Keyboard)
        //{
        //    i = 1;
        //}


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuHandler(int menuNum)
    {
        
         i = menuNum;
        
        switch (i)
        {
            case 0:
                foreach (GameObject menu in menus)
                {
                    menu.SetActive(false);
                }
                menus[0].SetActive(true);
                ;
                break;
            case 1:
                foreach (GameObject menu in menus)
                {
                    menu.SetActive(false);
                }
                menus[1].SetActive(true);
                ;
                break;
            case 2:
                foreach (GameObject menu in menus)
                {
                    menu.SetActive(false);
                }
                menus[2].SetActive(true);
                ;
                break;
            case 3:
                foreach (GameObject menu in menus)
                {
                    menu.SetActive(false);
                }
                menus[3].SetActive(true);
                ;
                break;
            case 4:
                foreach (GameObject menu in menus)
                {
                    menu.SetActive(false);
                }
                menus[4].SetActive(true);
                ;
                break;
            default: return;


        }
    }
}
