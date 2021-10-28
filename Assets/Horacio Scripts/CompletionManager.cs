using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionManager : MonoBehaviour
{
    public string scene;
    public int totalRooms;
    public bool mirrorsToComplete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mirrorsToComplete)
        {
            if (totalRooms == CompletedRoom.completed)
            {
                SceneManager.LoadScene(scene);
            }
        }
        else
        {
            if (BoxCompletion.completed)
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
