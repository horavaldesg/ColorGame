using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionManager : MonoBehaviour
{
    public string scene;
    public int totalRooms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalRooms == CompletedRoom.completed)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
