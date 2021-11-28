using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMirrorManager : MonoBehaviour
{
    public GameObject RoomManagerObj;
    public GameObject[] roomsOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoomManagerObj.SetActive(true);
            for (int i = 0; i < roomsOff.Length; i++)
            {
                roomsOff[i].SetActive(false);
            }
        }
        
    }
}
