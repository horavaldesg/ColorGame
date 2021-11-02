using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionManager : MonoBehaviour
{
    public string scene;
    public int totalRooms;
    public int totalBoxes;
    public bool mirrorsToComplete;
    public static float boxestoComplete;
    // Start is called before the first frame update
    void Start()
    {
        CompletedRoom.totalRooms = totalRooms;
        boxestoComplete = totalBoxes;

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
            if (MoveableObjects.completedBoxes == totalBoxes)
            {
                SceneManager.LoadScene(scene);
            }
        }
        //Debug.Log(MoveableObjects.completedBoxes);
    }
}
