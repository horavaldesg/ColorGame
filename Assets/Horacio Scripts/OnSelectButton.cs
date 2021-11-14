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
    public GameObject optionsMenu;
    public InputHandler ctScheme;
    
    // Start is called before the first frame update
    void Start()
    {
        //controls = new PlayerControls();
        //menu = GetComponent<EventSystem>().currentSelectedGameObject.name;
        //if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
        //{
        //    menu = "Controller";
        //}
        //else if (ctScheme.controlScheme == InputHandler.controlSchemes.Keyboard)
        //{
        //    menu = "Keyboard";
        //}
    }
    
    // Update is called once per frame
    void Update()
    {
        if(optionsMenu.activeSelf) {

            
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
                    //if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
                    //{
                    //    GameController.controls.UI1.Navigate.AddCompositeBinding("2DVector(mode=0)")
                    //        .With("Right", "<Gamepad>/rightShoulder")
                    //        .With("Left", "<Gamepad>/leftShoulder");

                    //}
                    break;
                case "Keyboard":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[1].SetActive(true);
                    //if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
                    //{
                    //    GameController.controls.UI1.Navigate.AddCompositeBinding("2DVector(mode=0)")
                    //       .With("Right", "<Gamepad>/rightShoulder")
                    //        .With("Left", "<Gamepad>/leftShoulder");

                    //}
                    break;
                case "Graphics":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[2].SetActive(true);
                    //if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
                    //{
                    //    GameController.controls.UI1.Navigate.AddCompositeBinding("2DVector(mode=0)")
                    //        .With("Right", "<Gamepad>/rightShoulder")
                    //        .With("Left", "<Gamepad>/leftShoulder");

                    //}
                    break;
                case "Audio":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[3].SetActive(true);
                    //if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
                    //{
                    //    GameController.controls.UI1.Navigate.AddCompositeBinding("2DVector(mode=0)")
                    //        .With("Right", "<Gamepad>/rightShoulder")
                    //        .With("Left", "<Gamepad>/leftShoulder");
                            
                    //}
                    
                    break;
                case "Accessibility":
                    foreach (GameObject selection in menus)
                    {
                        selection.SetActive(false);
                    }
                    menus[4].SetActive(true);
                    //if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
                    //{
                    //    GameController.controls.UI1.Navigate.AddCompositeBinding("2DVector(mode=0)")
                    //        .With("Right", "<Gamepad>/rightShoulder")
                    //        .With("Left", "<Gamepad>/leftShoulder");

                    //}

                    break;
                default: return;
                    //GameController.controls.UI1.Navigate.AddCompositeBinding("2DVector(mode=0)")
                    //  .With("Right", "<Gamepad>/leftStick/right")
                    //  .With("Left", "<Gamepad>/leftStick/left");
                    //break;

            }
            //Input Menu Handler
            
        }
    }
   
}
