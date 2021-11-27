﻿using UnityEngine;
using System.Collections;

public class RoomComplete : MonoBehaviour
{
    public GameObject[] sockets;
    public Collider mirrorCollider;
    GameObject player;
    public GameObject finishDoor;
    public AudioClip voiceClip;
    float voI;
    private static int onSocket;
    bool b = false;
    public static bool PassedTrigger;
    // Use this for initialization
    void Start()
    {
        PassedTrigger = false;
        player = GameObject.FindGameObjectWithTag("Player");
        voI = 0;
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
            
            //this.gameObject.SetActive(false);
        }

        if (PassedTrigger)
        {
            voI += Time.deltaTime;
        }

        if(voI > voiceClip.length)
        {
            finishDoor.SetActive(true);
        }
        Debug.Log(voI + " " + voiceClip.length);
        //Debug.Log(onSocket);
    }
    public static void OnSocket()
    {

        onSocket += 1;

    }
    
}

