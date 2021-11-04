using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public static bool triggerAnimationBool;
    public string animBoolName;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerAnimationBool = true;
            anim.SetBool(animBoolName, triggerAnimationBool);
        }
    }
}
