using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class OnSelectButton : MonoBehaviour
{
    string menu;
    public GameObject[] menus;
    // Start is called before the first frame update
    void Start()
    {
        //menu = GetComponent<EventSystem>().currentSelectedGameObject.name;

    }

    // Update is called once per frame
    void Update()
    {
            menu = GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>().GetComponent<EventSystem>().currentSelectedGameObject.name;
        //menu = GetComponent<EventSystem>().currentSelectedGameObject.name;
        //Debug.Log(menu);
            switch (menu)
            {
                case "Controller":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[0].SetActive(true);
                    ;
                    break;
                case "Keyboard":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[1].SetActive(true);
                    ;
                    break;
                case "Graphics":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[2].SetActive(true);
                    ;
                    break;
                case "Audio":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[3].SetActive(true);
                    ;
                    break;
                case "Accessibility":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[4].SetActive(true);
                    ;
                    break;
                default: return;

            
        }
    }
   
}
