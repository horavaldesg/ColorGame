using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour {
    public GameObject ojTransform;
    public GameObject LeftFootTrnf;
    public GameObject RightFootTrnf;

    public GameObject footStepTexture;
    float footsteps;
    [SerializeField] float footstepRate;
    float leftT;
    float rightT;
    [SerializeField]float altSteps;
    float tAltSteps;

    void Update()
    {
       
        RaycastHit hit;
        Debug.DrawRay(ojTransform.transform.position, transform.up, Color.red);
        if (Physics.Raycast(LeftFootTrnf.transform.position, -LeftFootTrnf.transform.up, out hit, 1))
        {
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                leftT += Time.deltaTime;
                if (leftT > footstepRate)
                {
                    Instantiate(footStepTexture, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
                    //Debug.Log("Ground");
                    leftT = 0;

                }
            }
            
        }
        tAltSteps += Time.deltaTime;
        if (tAltSteps > altSteps)
        {
            if (Physics.Raycast(RightFootTrnf.transform.position, -RightFootTrnf.transform.up, out hit, 1))
            {
                if (hit.collider.gameObject.CompareTag("Ground"))
                {
                    
                        Instantiate(footStepTexture, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
                        
                }
                
            }
            tAltSteps = 0;
        }
        //Hands
        if (Physics.Raycast(ojTransform.transform.position, ojTransform.transform.forward, out hit, 1))
        {
            /*
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                t += Time.deltaTime;
                if (t > footstepRate)
                {
                    Instantiate(footStepTexture, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
                    Debug.Log("Ground");
                    t = 0;

                }
            }
            */
        }
    }
}
