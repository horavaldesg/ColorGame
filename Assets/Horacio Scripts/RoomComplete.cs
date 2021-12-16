using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoomComplete : MonoBehaviour
{
    public GameObject[] sockets;
    public Collider mirrorCollider;
    GameObject player;
    public GameObject finishDoor;
    public AudioClip voiceClip;
    float voI;
    private int onSocket;
    bool b = false;
    public static bool PassedTrigger;

    public bool removePrevVO;
    public GameObject prevVO;

    public bool playNewVO;
    public GameObject newVO;
    public GameObject rippleEffect;
    // Use this for initialization
    void Start()
    {
        PassedTrigger = false;
        player = GameObject.FindGameObjectWithTag("Player");
        voI = 0;
        if(SceneManager.GetActiveScene().name != "Level 1")
        {
            this.gameObject.SetActive(false);

        }
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
        //Debug.Log(onSocket);
        if(onSocket == sockets.Length)
        {
            onSocket = 0;
            mirrorCollider.isTrigger = true;
            rippleEffect.SetActive(true);
            
            if (removePrevVO)
            {
                Destroy(prevVO);
            }
            if (playNewVO)
            {
                newVO.SetActive(true);
            }
           
            //this.gameObject.SetActive(false);
        }

        if (PassedTrigger)
        {
            voI += Time.deltaTime;
        }

        if(voI > voiceClip.length -5)
        {
            finishDoor.SetActive(true);
            voI = 0;
            PassedTrigger = false;
            
        }
        //Debug.Log(voI + " " + voiceClip.length);
        //Debug.Log(onSocket);
    }
    public void OnSocket()
    {

        onSocket += 1;

    }
    
}

