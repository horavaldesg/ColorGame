using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    public bool isOnCollider;
    public static int completedBoxes;
    public string boxName;
    // Start is called before the first frame update
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (boxName == other.gameObject.GetComponent<BoxCompletion>().boxName)
            {


                Rigidbody rb = other.GetComponent<Rigidbody>();
                other.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
                isOnCollider = true;
                completedBoxes += 1;
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
            //rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
