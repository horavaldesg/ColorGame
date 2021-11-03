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
    // Start is called before the first frame update
    private void Start()
    {
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
                other.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
                isOnCollider = true;
                completedBoxes += 1;
                Debug.Log(boxName);
                Debug.Log(other.gameObject.GetComponent<BoxCompletion>().boxName);
                collider.enabled = false;
                GameController.pullBox = false;
                GameController.boxPickup = false;
                GameController.moveableBox = null;
                if (completedBoxes % 2 == modNum && completedBoxes != 0 && completedBoxes != 1)
                {
                    
                    CompletedRoom.completed += 1;
                }
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
