using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    public static bool lifeSpan;
    GameObject[] respawnPoints;
    Color color;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BallDecay()
    {
        //Chage color to black
        //Intensity down

    }
    public void Respawn()
    {
        i = Random.Range(0, respawnPoints.Length);
        //Spawn Ball at GameObject[i].position

    }
}
