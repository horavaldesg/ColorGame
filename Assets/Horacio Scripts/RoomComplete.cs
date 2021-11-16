using UnityEngine;
using System.Collections;

public class RoomComplete : MonoBehaviour
{
    public GameObject[] sockets;
    public static Collider collider;
    public static int onSocket;
    bool b = false;
    // Use this for initialization
    void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = true;
        onSocket = 0;
        for (int i = 0; i < sockets.Length; i++)
        {
            //Debug.Log(sockets[i].GetComponent<MoveableObjects>().onSocket);
            if (sockets[i].GetComponent<MoveableObjects>().isOnCollider == false)
            {
                //onSocket += 1;
            }
        }
        //Debug.Log(onSocket);
    }

    // Update is called once per frame
    void Update()
    {

        if(onSocket == sockets.Length)
        {
            collider.isTrigger = true;
        }
        //Debug.Log(onSocket);
    }
    public static void OnSocket()
    {

        onSocket += 1;

    }
}

