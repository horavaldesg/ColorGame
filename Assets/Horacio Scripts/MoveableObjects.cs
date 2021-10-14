using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    Collider boxCollider;
    Rigidbody rb;
    public static Vector2 moveBox;
    public static Vector2 rotataBox;
    
    public float boxMoveSpeed;
    public Transform playerSocket;
    GameObject player;
    Transform camTransform;
    public float horizontalSensConst;
    public float verticalSensConst;
    float rotY;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.hasMoveableObject)
        {
            Vector3 movement = new Vector3(moveBox.x, 0, moveBox.y);
            rb.MovePosition(transform.position + (movement * boxMoveSpeed * Time.deltaTime));
            player.transform.position = playerSocket.position;
            Quaternion playerRotate = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            player.transform.rotation = playerRotate;
            camTransform = mainCamera.transform;
            //camTransform = FirstCam.transform;
            Vector2 r = new Vector2(0, rotataBox.x) * horizontalSensConst * Time.deltaTime * 10;
            transform.Rotate(r, Space.Self);
            Quaternion q = transform.rotation;
            q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
            transform.rotation = q;

            //Camera Rotation

            rotY += rotataBox.y * verticalSensConst * Time.deltaTime * 10;
            rotY = Mathf.Clamp(rotY, -90, 90);
            camTransform.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        }
        Debug.Log(moveBox);
    }
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            boxCollider.isTrigger = false;
            rb.useGravity = true;
            GameController.hasMoveableObject = true;
            
            Debug.Log(collision.gameObject.name);

        }
    }
}
