using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour {
    public GameObject ojTransform;
    public GameObject footStepTexture;
    float footsteps;
    [SerializeField] float footstepRate;
    float t;
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        RaycastHit hit;
        Debug.DrawRay(ojTransform.transform.position, transform.up, Color.red);
        if (Physics.Raycast(ojTransform.transform.position, ojTransform.transform.up, out hit, 1))
        {
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                t += Time.deltaTime;
                if (t > footstepRate)
                {
                    Instantiate(footStepTexture, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
                    Debug.Log("Ground");
                    t = 0;

                }




            }
        }
    }
}
