using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBall : MonoBehaviour
{
    public GameObject handTransform;
    [SerializeField] float distanceToDraw;
    public static bool ballTouching;
    public static bool canGrab;
    GameObject ball;
    bool hasBall;
    // Start is called before the first frame update
    void Start()
    {
        ballTouching = false;
        hasBall = false;
        canGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(handTransform.transform.position, handTransform.transform.forward, out hit, distanceToDraw))
        {
            if (hit.collider.CompareTag("Ball"))
            {
                canGrab = true;
                if (ballTouching)
                {
                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();

                    rb.constraints = RigidbodyConstraints.None;
                    hasBall = true;


                }

            }
        }
        if (hasBall)
        {
            ball.transform.position = handTransform.transform.position;
        }

        if (!ballTouching)
        {
            hasBall = false;
        }
           
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
           ball = other.gameObject;
            
            //ballTouching = true;

        }
        
    }

   
}
