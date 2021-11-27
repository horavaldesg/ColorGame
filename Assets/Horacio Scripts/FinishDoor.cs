using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    //Go through Door
    //Teleport Player back to mirror
    //Break Mirror
    //Counter +1 to room completed
    //Load Next Level when all rooms are completed
    GameObject player;
    public GameObject brokenMirror;
    public GameObject rippleEffect;
    public GameObject roomManager;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer();
        }
        

    }
    public void TeleportPlayer()
    {
        brokenMirror.SetActive(true);
        rippleEffect.SetActive(false);
        CompletedRoom.completed += 1;
        player.GetComponent<GameController>().cc.enabled = false;
        player.transform.position = CheckpointPos.lastPos;
        player.GetComponent<GameController>().cc.enabled = true;
        roomManager.SetActive(false);


    }
}
