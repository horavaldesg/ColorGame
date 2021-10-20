using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            other.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
            //rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
