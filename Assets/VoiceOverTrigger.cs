using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{

    public bool cutVO;
    public GameObject prevVO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoomComplete.PassedTrigger = true;
            if (cutVO)
            {
                Destroy(prevVO);
            }
        }
    }
}
