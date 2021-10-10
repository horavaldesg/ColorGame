using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBall : MonoBehaviour
{
    public GameObject handTransform;
    [SerializeField] float distanceToDraw;
    Rigidbody rb;
    public static bool ballTouching;
    GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(handTransform.transform.position, handTransform.transform.forward, out hit, distanceToDraw))
        {
            if (hit.collider.CompareTag("Ball"))
            {
                if (ballTouching)
                {
                    ball.transform.position = handTransform.transform.position;
                }
            }
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
