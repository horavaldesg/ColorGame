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
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        CompletedRoom.totalRooms = totalRooms;
        boxestoComplete = totalBoxes;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        */
        if(CompletedRoom.completed == totalRooms)
        {
            player.GetComponent<GameController>().transtitionOut.SetActive(true);
            StartCoroutine(enumerator());
            
        }
         IEnumerator enumerator()
        {

            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(scene);
        }
        //Debug.Log(MoveableObjects.completedBoxes);
    }
    
}
