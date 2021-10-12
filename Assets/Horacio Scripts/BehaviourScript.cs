using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BehaviourScript : MonoBehaviour
{
    //public GameObject player;
    NavMeshAgent agent;
    public Transform[] target;
    AudioSource audioSc;
    Rigidbody rb;
    float speed = 3f;
    float minDistance = 10;
    float safeDistance = 10;
    float specPos = 20;
    int i;
    public enum BehaviorState {Copy, Seek, Flee};

    public BehaviorState currentState;
    // Start is called before the first frame update
    void Start()
    {
        Randomize();
        audioSc = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case BehaviorState.Copy: Randomize();
                break;
            case BehaviorState.Seek: Seek();
                break;
            case BehaviorState.Flee: Flee();
                break;
            default: Debug.Log("Switch error");
                break;
        }
        
       
        
    }

    void Seek()
    {
        Vector3 differenceVector = target[i].position - transform.position;
        if (differenceVector.magnitude > minDistance)
        {
            agent.destination = target[i].position;
            //rb.MovePosition(transform.position + moveVector);
            

        }
        else
        {
            Randomize();
            //PlayerMovement.canMove = false;
            //agent.destination = transform.position;
        }
    }
    void Flee()
    {

        Vector3 differenceVector = transform.position - target[0].position;
        if(differenceVector.magnitude < safeDistance)
        {
            agent.destination = transform.position + differenceVector;
            

        }
        else
        {
            Seek();
            //agent.destination = transform.position;
        }


    }
    void Randomize()
    {
        i = Random.Range(0, target.Length);
    }
}
