using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public CharacterController cc;
    public GameObject LeftFootTrnf;
    public GameObject RightFootTrnf;

    public GameObject handTransform;

    public GameObject footStepTexture;
    public GameObject handPrintTexture;

    float footsteps;
    [SerializeField] float footstepRate;
    float leftT;
    float rightT;
    [SerializeField] float altSteps;
    float tAltSteps;

    void Update()
    {

        RaycastHit hit;
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
        if (Physics.Raycast(handTransform.transform.position, handTransform.transform.forward, out hit, 0.5f))
        {
            if (hit.collider.gameObject.CompareTag("XLeft"))
            {
                Instantiate(handPrintTexture, hit.point + Vector3.forward * -0.01f, Quaternion.Euler(-90, 0, 0));
            }
            else if (hit.collider.gameObject.CompareTag("XRight"))
            {
                Instantiate(handPrintTexture, hit.point + Vector3.forward * 0.01f, Quaternion.Euler(90, 0, 0));
            }
            else if (hit.collider.gameObject.CompareTag("ZRight"))
            {
                Instantiate(handPrintTexture, hit.point + Vector3.forward * -0.01f, Quaternion.Euler(0, 0, 90));
            }
            else if (hit.collider.gameObject.CompareTag("ZLeft"))
            {
                Instantiate(handPrintTexture, hit.point + Vector3.forward * 0.01f, Quaternion.Euler(0, 0, -90));
            }
            else if (hit.collider.gameObject.CompareTag("Top"))
            {
                Instantiate(footStepTexture, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));

            }
            
            
            
        }
       
        if (Physics.SphereCast(transform.position - cc.center, cc.height / 2, transform.forward, out hit, 1))
        {
            if (hit.collider.gameObject.layer == 9 || hit.collider.CompareTag("HandPrint"))
            {
                GameController.canMove = false;

            }
        }
        else
        {
            GameController.canMove = true;
        }
    }
}
