using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChangeFirstSelected : MonoBehaviour
{
    EventSystem eventSystem;
    public InputHandler ctScheme;
    public GameObject controller;
    public GameObject keyboard;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GetComponent<EventSystem>();
        //if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
        //{
        //    FirstSelected(controller);
        //}
        //else if (ctScheme.controlScheme == InputHandler.controlSchemes.Keyboard)
        //{
        //    FirstSelected(keyboard);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstSelected(GameObject firstSelected)
    {
        eventSystem.SetSelectedGameObject(firstSelected, new BaseEventData(eventSystem));
    }
}
