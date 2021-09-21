using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamChange : MonoBehaviour
{
    public GameObject FirstCam;
    public GameObject ThirdCam;

    public int CamMode;

    void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
        }

        Vector2 move = gamepad.leftStick.ReadValue();
        // 'Move' code here
    }

    public void CamViewChange()
    {
        if (CamMode == 1)
        {
            CamMode = 0;

        }
        else
        {
            CamMode += 1;

        }

        StartCoroutine(CameraChange());
    }


    IEnumerator CameraChange()
    {
        yield return new WaitForSeconds(.02f);

        if (CamMode == 0)
        {
            FirstCam.SetActive(false);
            ThirdCam.SetActive(true);
        }
        
        if(CamMode == 1)
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    }
}


/*
  //Player Rotation
        if (CamMode == 0)
        {
            camTransform = ThirdCam.transform;
            Vector2 r = new Vector2(0, rotate.x) * horizontalSens * Time.deltaTime;
            transform.Rotate(r, Space.Self);
            Quaternion q = transform.rotation;
            q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
            transform.rotation = q;

            //Camera Rotation

            rotY += -rotate.y * verticalSens * Time.deltaTime;
            rotY = Mathf.Clamp(rotY, -90, 90);
            camTransform.transform.localRotation = Quaternion.Euler(rotY, 0, 0);


        }
        else if (CamMode == 1)
        {

            camTransform = FirstCam.transform;
            Vector2 r = new Vector2(0, rotate.x) * horizontalSens * Time.deltaTime;
            transform.Rotate(r, Space.Self);
            Quaternion q = transform.rotation;
            q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
            transform.rotation = q;

            //Camera Rotation

            rotY += -rotate.y * verticalSens * Time.deltaTime;
            rotY = Mathf.Clamp(rotY, -90, 90);
            camTransform.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        }
  */