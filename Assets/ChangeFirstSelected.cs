using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChangeFirstSelected : MonoBehaviour
{
    EventSystem eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstSelected(GameObject firstSelected)
    {
        eventSystem.firstSelectedGameObject = firstSelected;
    }
}
