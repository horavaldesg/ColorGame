using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMirror : MonoBehaviour
{
    Transform rot;
    public GameObject room1;
    // Start is called before the first frame update
    void Start()
    {
        rot = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision " + rot.transform.localEulerAngles.y);
        if(rot.localEulerAngles.y == 0)
        {
            rot.rotation = Quaternion.Euler(rot.localEulerAngles.x, 180, rot.localEulerAngles.z);
            room1.SetActive(true);
        }
        else if (rot.transform.localEulerAngles.y == 180)
        {
            rot.rotation = Quaternion.Euler(rot.localEulerAngles.x, 0, rot.localEulerAngles.z);
            room1.SetActive(false);
        }
    }
}
