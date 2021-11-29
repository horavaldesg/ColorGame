using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBall : MonoBehaviour
{
    public Animator anim;
    public static Animator staticAnim;
    public GameObject handTransform;
    [SerializeField] float distanceToDraw;
    public GameObject interactionText;
    GameObject camTransform;
    public static bool ballTouching;
    public static bool canGrab;
    public static GameObject ball;
    public static bool hasBall;
    public static bool canShoot;
    Color lerpColor;
    //Ball Timer 
    [SerializeField] float timeDecrease;
    [SerializeField] float timeIncrease;
    //Audio
    [FMODUnity.EventRef]
    public string throwSound;

    // Start is called before the first frame update
    void Start()
    {
        staticAnim = anim;
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
        //Decrease light
        if (hasBall)
        {
            anim.SetBool("HoldingBall", true);
            
            float t = 0;
            if (ball.GetComponentInChildren<Light>().intensity > 0)
            {
                t += Time.deltaTime * timeDecrease / 2;
                ball.GetComponentInChildren<Light>().intensity -= Time.deltaTime * timeDecrease;
                ball.GetComponentInChildren<Light>().range -= Time.deltaTime * timeDecrease;
                lerpColor = Color.Lerp(ball.GetComponent<Renderer>().material.GetColor("_EmissionColor"), Color.black, t);
                ball.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", lerpColor);

            }
            ball.transform.position = handTransform.transform.position;
            ball.transform.rotation = handTransform.transform.rotation;
            interactionText.SetActive(false);
        }
        else
        {
            //Increase light
            if (ball != null)
            {
                float t = 0;
                if (ball.GetComponentInChildren<Light>().intensity < 6 && ball.GetComponentInChildren<Light>().intensity < 7.5f)
                {
                    t += Time.deltaTime * timeIncrease / 2;

                    ball.GetComponentInChildren<Light>().intensity += Time.deltaTime * timeIncrease;
                    ball.GetComponentInChildren<Light>().range += Time.deltaTime * timeIncrease;
                    lerpColor = Color.Lerp(ball.GetComponent<Renderer>().material.GetColor("_EmissionColor"), Color.white, t);
                    ball.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", lerpColor);
                }

                // PUT 3D SOUND HERE
            }
        }
        if (!ballTouching)
        {
            hasBall = false;
            anim.SetBool("HoldingBall", false);
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
            staticAnim.SetTrigger("ThrowBall");

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
