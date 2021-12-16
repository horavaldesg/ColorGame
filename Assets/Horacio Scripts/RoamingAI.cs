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
    GameObject playerObj;
    AudioSource audioSc;
    Rigidbody rb;
    float speed = 3f;
    float minDistance = 10;
    float safeDistance = 10;
    public float distanceToPlayer;
    public float distanceToBall;
    public float distanceToPrints;
    float specPos = 20;
    int i;
    float t = 0;
    [SerializeField] float distanceToRemove;
    GameObject[] paints;
    GameObject ball;

    Vector3 momTransform;
    public enum BehaviorState { SeekPlayer, Seek, Stop, SeekInOrder, SeekBall, SeekHands};

    public BehaviorState currentState;
    // Start is called before the first frame update
    void Start()
    {
        momTransform = this.gameObject.transform.position;
        ball = GameObject.FindGameObjectWithTag("Ball");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
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
        paints = GameObject.FindGameObjectsWithTag("HandPrint");
        Debug.Log(momTransform);
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
            case BehaviorState.SeekHands:
                SeekPaint();
                break;
            case BehaviorState.SeekBall:
                SeekBall();
                break;
            default: Debug.Log("Switch error");
                break;
        }

        //Roaming AI Priority List
        //Hand Prints (Short Range), Player (Med Range), Light Ball (Long Range)
        
        Vector3 playerVector = player.transform.position - transform.position;
        Vector3 ballVector = ball.transform.position - transform.position;
        if (paints != null)
        {
            Vector3 handVector = paints[paints.Length - 1].transform.position - transform.position;
            if (handVector.magnitude < distanceToPrints && handVector.magnitude < distanceToPlayer)
            {
                currentState = BehaviorState.SeekHands;
            }
            //Debug.Log("Hand Distance: " + distanceToPrints + "Hand Vector" + handVector.magnitude);

        }

        if (playerVector.magnitude < distanceToPlayer && playerVector.magnitude > distanceToPrints)
        {
            currentState = BehaviorState.SeekPlayer;
        }
         if (ballVector.magnitude < distanceToBall && ballVector.magnitude > distanceToPlayer)
        {
            currentState = BehaviorState.SeekBall;
        }
        //Debug.Log("Player Distance: " + distanceToPlayer + " Player Vector" + playerVector.magnitude);
        //Debug.Log("Ball Distance: " + distanceToBall + " Ball Vector" + ballVector.magnitude);
        if(agent.velocity == Vector3.zero)
        {
            currentState = BehaviorState.Seek;
        }

        /*
        RaycastHit hit;
        if (Physics.Raycast(agent.transform.position, agent.transform.forward, out hit, distanceToRemove))
        {
            if (hit.collider.CompareTag("Player"))
            {
                //End Sequence
                //Debug.Log("Collided with " + hit.collider.gameObject.name);
                currentState = BehaviorState.SeekPlayer;
            }
           

        }
        /*
        if(paints != null)
        {
            currentState = BehaviorState.SeekHands;
        }
        */
    }
    void SeekPaint()
    {
        
        paints = GameObject.FindGameObjectsWithTag("HandPrint");
        int i = paints.Length - 1;
        Vector3 differenceVector = paints[i].transform.position - transform.position;
        if (differenceVector.magnitude > minDistance)
        {
            agent.destination = paints[i].transform.position;
        }
        /*
        if (i < 5)
        {
            
        }

        else
        {
            t = 0;
            //currentState = BehaviorState.SeekBall;
        }
        */


    }
    void SeekBall()
    {
        
        Vector3 differenceVector = ball.transform.position - transform.position;
        if (differenceVector.magnitude > minDistance)
        {

            agent.destination = ball.transform.position;

        }
        /*
        if(t < 3)
        {
            

        }
        else
        {
            t = 0;
            currentState = BehaviorState.SeekPlayer;

        }
        */
        
    }
    void SeekInOrder()
    {
        Vector3 differenceVector = target[i].position - transform.position;
        if (differenceVector.magnitude > minDistance)
        {
            agent.destination = target[i].position;


        }
        /*
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
            
        }
        */
    }
    void Seek()
    {
        Vector3 differenceVector = target[i].position - transform.position;
        if (differenceVector.magnitude > minDistance)
        {
            agent.destination = target[i].position;
            

        }
        else
        {
            Randomize();
           
        }
    }
    void Stop()
    {

        //agent.destination = transform.position;
        

    }
    void Randomize()
    {
        i = Random.Range(0, target.Length);
    }
    void SeekPlayer()
    {
       
        t += Time.deltaTime;
        //if (t < 3)
        //{
            Vector3 differenceVector = player.position - transform.position;
            if (differenceVector.magnitude > minDistance)
            {
                agent.destination = player.position;


            }
           
        //}
        //else
        //{
            //t = 0;
            //currentState = BehaviorState.Seek;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerObj.GetComponent<GameController>().transtionCaught.SetActive(true);
            
            //Debug.Log(clipTime);
            StartCoroutine(loadScene(other.gameObject,2));
            
            //Debug.Log("Caught");
        }
        if (other.gameObject.CompareTag("HandPrint"))
        {
            Destroy(other.gameObject);
        }

    }
    private IEnumerator loadScene(GameObject other,float time)
    {
        yield return new WaitForSeconds(time);
        //SceneManager.LoadScene(currentScene.name);
        RespawnPlayer(other.gameObject);
        agent.Warp(momTransform);
        playerObj.GetComponent<GameController>().transtionCaught.SetActive(false);


    }
    void RespawnPlayer(GameObject playerObj)
    {
        playerObj.gameObject.GetComponent<GameController>().Respawn();

    }
}
