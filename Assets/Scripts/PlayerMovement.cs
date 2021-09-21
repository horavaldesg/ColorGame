using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Starter/Foundation Code Taught and Inspired by One Wheel Studio https://www.youtube.com/watch?v=WIl6ysorTE0

    private ColorGame actionAsset;
    private InputAction move;

    //movement
    private Rigidbody rb;
    [SerializeField]
    private float moveForce = 1f;
    float jumpForce = 4f;
    float maxSpeed = 5f;
    Vector3 moveDirection = Vector3.zero;

    //rotation
    public Camera playerCamera;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        actionAsset = new ColorGame();
    }

    void OnEnable()
    {
        actionAsset.Player.Jump.started += JumpUp;
        move = actionAsset.Player.Move;
        actionAsset.Player.Enable();
    }

    void OnDisable()
    {
        actionAsset.Player.Jump.started -= JumpUp;
        actionAsset.Player.Disable();
    }

    private void FixedUpdate()
    {
        moveDirection += move.ReadValue<Vector2>().x * GetCamForward(playerCamera) * moveForce;
        moveDirection += move.ReadValue<Vector2>().y * GetCamRight(playerCamera) * moveForce;

        rb.AddForce(moveDirection, ForceMode.Impulse);
        moveDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.deltaTime;

        Vector3 horizontalVel = rb.velocity;
        horizontalVel.y = 0;
        if (horizontalVel.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVel.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }


    private Vector3 GetCamRight(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;

    }

    private Vector3 GetCamForward(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    public void JumpUp(InputAction.CallbackContext obj)
    {
        if (Grounded())
        {
            moveDirection += Vector3.up * jumpForce;
        }
    }

    private bool Grounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            return false;
        }
        else
            return true;

    }
}
