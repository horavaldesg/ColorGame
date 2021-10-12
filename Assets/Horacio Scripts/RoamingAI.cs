using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RoamingAI : MonoBehaviour
{
    //public GameObject player;
    NavMeshAgent agent;
    public float detectionDistance;
    public Transform[] target;
    public Transform player;
    AudioSource audioSc;
    Rigidbody rb;
    float speed = 3f;
    float minDistance = 10;
    float safeDistance = 10;
    float specPos = 20;
    int i;
    float t = 0;
    public enum BehaviorState { SeekPlayer, Seek, Stop};

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
        Debug.Log(t);
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case BehaviorState.SeekPlayer: SeekPlayer();
                break;
            case BehaviorState.Seek: Seek();
                break;
            case BehaviorState.Stop: Stop();
                break;
            default: Debug.Log("Switch error");
                break;
        }

        RaycastHit hit;
        if (Physics.Raycast(agent.transform.position, agent.transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                //End Sequence
                //Debug.Log("Collided with " + hit.collider.gameObject.name);
                currentState = BehaviorState.SeekPlayer;
            }
            

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
    void Stop()
    {

        agent.destination = transform.position;


    }
    void Randomize()
    {
        i = Random.Range(0, target.Length);
    }
    void SeekPlayer()
    {
       
        t += Time.deltaTime;
        if (t < 3)
        {
            Vector3 differenceVector = player.position - transform.position;
            if (differenceVector.magnitude > minDistance)
            {
                agent.destination = player.position;
                //rb.MovePosition(transform.position + moveVector);


            }
           
        }
        else
        {
            
            currentState = BehaviorState.Seek;
        }
    }
}
