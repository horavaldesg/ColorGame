using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBall : MonoBehaviour
{
    public GameObject handTransform;
    [SerializeField] float distanceToDraw;
    public GameObject interactionText;
    GameObject camTransform;
    public static bool ballTouching;
    public static bool canGrab;
    public static GameObject ball;
    public static bool hasBall;
    public static bool canShoot;
    public AudioSource throwSound;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = GameObject.FindGameObjectWithTag("MainCamera");
        ballTouching = false;
        hasBall = false;
        canGrab = false;
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTransform.transform.position, camTransform.transform.forward, out hit, distanceToDraw))
        {
            if (hit.collider.CompareTag("Ball"))
            {
                interactionText.SetActive(true);
                ball = hit.collider.gameObject;
                canGrab = true;
                //Debug.Log(canGrab);
                if (ballTouching)
                {
                    Rigidbody rb = ball.gameObject.GetComponent<Rigidbody>();

                    rb.constraints = RigidbodyConstraints.None;

                    hasBall = true;


                }

            }
        }
        else
        {
            interactionText.SetActive(false);
        }
        if (hasBall)
        {
            ball.transform.position = handTransform.transform.position;
            ball.transform.rotation = handTransform.transform.rotation;
            interactionText.SetActive(false);
        }

        if (!ballTouching)
        {
            hasBall = false;
        }

        if (canShoot)
        {
            throwSound.Play();
            hasBall = false;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(ball.transform.forward * 15, ForceMode.Impulse);
            ballTouching = false;
            canGrab = false;
            canShoot = false;
        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ball"))
    //    {
    //       ball = other.gameObject;
            
    //        //ballTouching = true;

    //    }
        
    //}
    public static void PickUp()
    {
        if (canGrab)
        {
            ballTouching = !ballTouching;
            canGrab = false; 

        }
    }
   public static void Shoot(GameObject handTransform)
    {
        if (hasBall)
        {
            canShoot = true;
        }
    }
}
