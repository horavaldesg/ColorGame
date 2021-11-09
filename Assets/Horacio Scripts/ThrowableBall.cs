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

    //Audio
    [FMODUnity.EventRef]
    public string throwSound;

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
            if (ball.GetComponentInChildren<Light>().intensity > 0)
            {
                ball.GetComponentInChildren<Light>().intensity -= Time.deltaTime * 0.5f;
                ball.GetComponentInChildren<Light>().range -= Time.deltaTime * 0.5f;

            }
            ball.transform.position = handTransform.transform.position;
            ball.transform.rotation = handTransform.transform.rotation;
            interactionText.SetActive(false);
        }
        else
        {
            if (ball != null)
            {
                if (ball.GetComponentInChildren<Light>().intensity < 6 && ball.GetComponentInChildren<Light>().intensity < 7.5f)
                {
                    ball.GetComponentInChildren<Light>().intensity += Time.deltaTime * 0.5f;
                    ball.GetComponentInChildren<Light>().range += Time.deltaTime * 0.5f;

                }
            }
        }
        if (!ballTouching)
        {
            hasBall = false;
        }

        if (canShoot)
        {
            PlayThrow(throwSound);
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
            RespawnBall.lifeSpan = true;
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

    void PlayThrow(string path)
    {
        FMOD.Studio.EventInstance Throw = FMODUnity.RuntimeManager.CreateInstance(path);
        Throw.start();
        Throw.release();

    }
}
