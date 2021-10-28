using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCompletion : MonoBehaviour
{
    GameObject[] boxes;
    public static bool completed;
    // Start is called before the first frame update
    void Start()
    {
        completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        boxes = GameObject.FindGameObjectsWithTag("Socket");
        foreach(GameObject box in boxes)
        {
            if (box.GetComponent<MoveableObjects>().isOnCollider)
            {
                completed = true;
            }
        }
    }
}
