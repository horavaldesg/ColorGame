using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    public bool isOnCollider;
    public static int completedBoxes;
    public string boxName;
    float modNum;
    Collider collider;
    public static bool onSocket;
    public RoomComplete roomComplete;
    // Start is called before the first frame update
    private void Start()
    {
        onSocket = false;
        collider = GetComponent<Collider>();
        completedBoxes = 0;
    }
    private void Update()
    {
        if(CompletionManager.boxestoComplete % 2 == 0)
        {
            modNum = 0;
        }
        else if(CompletionManager.boxestoComplete % 2 == 1)
        {
            modNum = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (boxName == other.gameObject.GetComponent<BoxCompletion>().boxName && other.gameObject.GetComponent<BoxCompletion>() != null)
            {


                Rigidbody rb = other.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                other.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
                other.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.eulerAngles.y, transform.rotation.z);
                isOnCollider = true;
                completedBoxes += 1;
                rb.isKinematic = true;
                other.GetComponent<Collider>().enabled = false;
                //Debug.Log(boxName);
                //Debug.Log(other.gameObject.GetComponent<BoxCompletion>().boxName);
                collider.enabled = false;
                ThrowableBall.pullBox = false;
                ThrowableBall.boxPickup = false;
                ThrowableBall.moveableBox = null;
                ThrowableBall.canPickup = false;
                roomComplete.OnSocket();
                //if (completedBoxes % 2 == modNum && completedBoxes != 0 && completedBoxes != 1)
                //{
                    
                //    CompletedRoom.completed += 1;
                //    //Make mirror active
                //}
            }
            //rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            //Rigidbody rb = other.GetComponent<Rigidbody>();
            //other.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
            isOnCollider = false;
            //completedBoxes -= 1;
            //rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
