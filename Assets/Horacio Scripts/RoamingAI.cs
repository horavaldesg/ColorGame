using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class RoamingAI : MonoBehaviour
{
    //public GameObject player;

    Scene currentScene;

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
    public enum BehaviorState { SeekPlayer, Seek, Stop, SeekInOrder};

    public BehaviorState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        //Randomize();
        audioSc = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(t);
    }

    private void FixedUpdate()
    {
        //Debug.Log(i);
        switch (currentState)
        {
            case BehaviorState.SeekPlayer: SeekPlayer();
                break;
            case BehaviorState.Seek: Seek();
                break;
            case BehaviorState.Stop: Stop();
                break;
            case BehaviorState.SeekInOrder: SeekInOrder();
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
    void SeekInOrder()
    {
        Vector3 differenceVector = target[i].position - transform.position;
        if (differenceVector.magnitude > minDistance)
        {
            agent.destination = target[i].position;
            //rb.MovePosition(transform.position + moveVector);


        }
        else
        {
            if(i == target.Length - 1)
            {
                i = 0;
            }
            else
            {
                i += 1;
            }
            //PlayerMovement.canMove = false;
            //agent.destination = transform.position;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Animator anim = other.GetComponent<Animator>();
            anim.SetBool("Caught", true);
            
            float clipTime = anim.runtimeAnimatorController.animationClips[5].length;
            
            
            Debug.Log(clipTime);
            StartCoroutine(loadScene(clipTime));
            Debug.Log("Caught");
        }
    }
    private IEnumerator loadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(currentScene.name);

    }
}
