using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour {
    public GameObject mainCamera;
    public GameObject splashTexture;
    float footsteps;
    [SerializeField] float footstepRate;
    float t;
	void Update ()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            RaycastHit hit;
        Debug.DrawRay(mainCamera.transform.position, transform.up, Color.red);
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.up, out hit, 1))
            {
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                t += Time.deltaTime;
                if (t > footstepRate)
                {
                    Instantiate(splashTexture, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
                    Debug.Log("Ground");
                    t = 0;

                }
                

                

            }
                //MyShaderBehavior script = hit.collider.gameObject.GetComponent<MyShaderBehavior>();
                //if (null != script)
                    //script.PaintOn(hit.textureCoord, splashTexture);
            }
        }
	//}
}
