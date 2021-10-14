using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionManager : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CompletedRoom.totalCompleted == CompletedRoom.completed)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
