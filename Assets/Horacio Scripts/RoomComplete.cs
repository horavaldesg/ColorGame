using UnityEngine;
using System.Collections;

public class RoomComplete : MonoBehaviour
{
    public GameObject[] sockets;
    public Collider mirrorCollider;
    private static int onSocket;
    bool b = false;
    // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(false);
        mirrorCollider.enabled = true;
        onSocket = 0;
        //for (int i = 0; i < sockets.Length; i++)
        //{
        //    //Debug.Log(sockets[i].GetComponent<MoveableObjects>().onSocket);
        //    if (sockets[i].GetComponent<MoveableObjects>().isOnCollider == false)
        //    {
        //        //onSocket += 1;
        //    }
        //}
        //Debug.Log(onSocket);
    }

    // Update is called once per frame
    void Update()
    {

        if(onSocket == sockets.Length)
        {
            mirrorCollider.isTrigger = true;
            onSocket = 0;
            this.gameObject.SetActive(false);
        }
        //Debug.Log(onSocket);
    }
    public static void OnSocket()
    {

        onSocket += 1;

    }
}

