using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomEnter : MonoBehaviour
{
    public GameObject col;
    //public string scene;
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
        if (other.gameObject.CompareTag("Player"))
        {
            CompletedRoom.completed += 1;
            Destroy(col);
        }
    }
}
