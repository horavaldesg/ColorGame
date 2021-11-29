using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FreezeBall : MonoBehaviour
{
    Rigidbody rb;
    AudioSource ballBounce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballBounce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

            ballBounce.Play();
        }
    }
}
