using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    //Controller
    PlayerControls controls;
    //Camera
    Camera mainCamera;
    public Transform camTransform;
    float FOVConst;
    public GameObject FirstCam;
    //public GameObject ThirdCam;

    public int CamMode;

    GameObject handTransform;
    //Sensitivity
    [SerializeField] FloatVariable horizontalSens;
    [SerializeField] FloatVariable verticalSens;
    [SerializeField] FloatVariable controllerHorizontalSens;
    [SerializeField] FloatVariable controllerVerticalSens;

    float horizontalSensConst;
    float verticalSensConst;
    float rotY;

    //Jumping/Gravity
    [SerializeField] Transform checkPos;
    public LayerMask groundMask;

    bool grounded;
    float Gravity = -25;
    float verticalSpeed = 0;
    public float jumpSpeed = 9;

    //Movement
    public static Vector2 move;
    Vector2 rotate;

    public static int shotCount;
    
    [SerializeField] CharacterController cc;

    Vector3 movement;

    [SerializeField] float speed = 3;
    [SerializeField] float speedBoost = 1;



    //LightBar
    DualShockGamepad gamepad;

    public static bool canMove;
    //Rumbles
    public enum controlSchemes {Gamepad, Keyboard };

    public controlSchemes controlScheme;

    public GameObject OptionsObj;
    public GameObject clickScript;
    public bool PaintOnClick;
    public static bool paintOnClick;

    public static bool hasMoveableObject;

    public float boxPush = 2.0f;

    public AudioSource footstepsAudio;

    public UnityEvent changeFirstSelected;
    private void Awake()
    {
        hasMoveableObject = false;
        paintOnClick = PaintOnClick;

        if (gamepad != null)
        {
            gamepad = (DualShockGamepad)Gamepad.all[0];
            gamepad.SetLightBarColor(Color.green);
        }


        //Main Camera
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        FOVConst = mainCamera.fieldOfView;



        //Constants
        speedBoost = 1;
        //horizontalSens = 100f;
        //verticalSens = 100f;
        horizontalSensConst = horizontalSens.Value;
        verticalSensConst = verticalSens.Value;
        controls = new PlayerControls();
        //Jump
        controls.Gameplay.Jump.started += tgb => Jump();

        //Change Camera
        // controls.Gameplay.ChangeCamera.performed += tgb => CamViewChange();

        //Movement
        controls.Gameplay.Move.performed += tgb => footstepsAudio.Play();
        controls.Gameplay.Move.performed += tgb => move = tgb.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += tgb => move = Vector3.zero;
        controls.Gameplay.Move.canceled += tgb => movement = Vector3.zero;


        //Run
        //controls.Gameplay.SpeedBoost.performed += tgb => speedBoost = 3;
        //controls.Gameplay.SpeedBoost.canceled += tgb => speedBoost = 1;

        //Rotation
        controls.Gameplay.Rotation.performed += tgb => rotate = tgb.ReadValue<Vector2>();
        controls.Gameplay.Rotation.canceled += tgb => rotate = Vector2.zero;


        //Options
        if (OptionsObj != null)
        {
            controls.Gameplay.Options.performed += tgb => OptionsManager();
            controls.UI.Options.performed += tgb => OptionsManager();


            controls.Gameplay.Circle.performed += tgb => OptionsObj.SetActive(false);
            controls.UI.Circle.performed += tgb => OptionsObj.SetActive(false);

        }
        canMove = true;
        //Shoot
        if (PaintOnClick)
        {
            controls.Gameplay.Shoot.performed += tgb => clickScript.GetComponent<ClickScript>().PaintonClick();
            controls.Gameplay.Shoot.canceled += tgb => AnimationScript.handClick = false;
        }

        //Interaction

        controls.Gameplay.Interaction.performed += tgb => ThrowableBall.PickUp();


        //Shoot
        controls.Gameplay.Shoot.performed += tgb => ThrowableBall.Shoot(handTransform);

    }
    public void OptionsManager()
    {
        OptionsObj.SetActive(!OptionsObj.activeSelf);
        changeFirstSelected.Invoke();
    }
    public void Jump()
    {
        if (grounded)
        {
            AnimationScript.jump = true;
            verticalSpeed = jumpSpeed;
            grounded = false;
        }
    }
   
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        //gamepad.ResetHaptics();
        controls.Gameplay.Disable();

    }

    public void Update()
    {
        
        if (OptionsObj.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            //InputActionMap
            controls.UI.Enable();

            controls.Gameplay.Disable();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            controls.UI.Disable();

            controls.Gameplay.Enable();
        }
        if (controlScheme == controlSchemes.Gamepad)
        {
            InputBinding actionMask = new InputBinding { groups = "Gamepad" };
            InputTextManager.inputText = "Press Square to Interact";
            horizontalSensConst = controllerHorizontalSens.Value;
            verticalSensConst = controllerVerticalSens.Value;
            controls.bindingMask = actionMask;
        }
        else if (controlScheme == controlSchemes.Keyboard)
        {
            InputBinding actionMask = new InputBinding { groups = "KBM" };
            InputTextManager.inputText = "Press E to Interact";
            horizontalSensConst = horizontalSens.Value;
            verticalSensConst = verticalSens.Value;
            controls.bindingMask = actionMask;
        }
        
        
        camTransform = mainCamera.transform;
       
        movement = Vector3.zero;

        //Forward/Backward Movement
        float forwardSpeed = move.y * speed * speedBoost * Time.deltaTime;

        //if (canMove)
        //{
            movement += transform.forward * forwardSpeed;
        //}
        //else if(!canMove && move.y < 0)
        //{
        //    movement += transform.forward * forwardSpeed;
        //    canMove = true;
        //}

        //Debug.Log (move.y);
        //Debug.Log(canMove);
        //Left/Right Movement
        float sideSpeed = move.x * speed * speedBoost * Time.deltaTime;
        movement += transform.right * sideSpeed;

        //Movement Animator

        //Gravity
        verticalSpeed += Gravity * Time.deltaTime;
        movement += transform.up * verticalSpeed * Time.deltaTime;


        //Ground Check
        if (Physics.CheckSphere(checkPos.position, 0.5f, groundMask) && verticalSpeed <= 0)
        {
            AnimationScript.jump = false;
            grounded = true;
            verticalSpeed = 0;
        }
        if (!hasMoveableObject)
        {
            cc.enabled = true;
            cc.Move(movement);
        }
        else if (hasMoveableObject)
        {
            cc.enabled = false;
        }
        

        //Player Rotation
        //Third Person
        /*
        if (!OptionsObj.activeSelf)
        {
            if (CamMode == 0)
            {
                camTransform = ThirdCam.transform;
                Vector2 r = new Vector2(0, rotate.x) * horizontalSensConst * Time.deltaTime * 10;
                transform.Rotate(r, Space.Self);
                Quaternion q = transform.rotation;
                q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
                transform.rotation = q;

                //Camera Rotation

                rotY += -rotate.y * verticalSensConst * Time.deltaTime * 10;
                rotY = Mathf.Clamp(rotY, -90, 90);
                camTransform.transform.localRotation = Quaternion.Euler(rotY, 0, 0);


            }
        */
            //First Person
           // else if (CamMode == 1)
            //{

                camTransform = FirstCam.transform;
                Vector2 r = new Vector2(0, rotate.x) * horizontalSensConst * Time.deltaTime * 10;
                transform.Rotate(r, Space.Self);
                Quaternion q = transform.rotation;
                q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
                transform.rotation = q;

                //Camera Rotation

                rotY += -rotate.y * verticalSensConst * Time.deltaTime * 10;
                rotY = Mathf.Clamp(rotY, -90, 90);
                camTransform.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
            //}
      // }
        
    }
    /*
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

        if (CamMode == 1)
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    */
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Box"))
        {
            Rigidbody box = hit.collider.GetComponent<Rigidbody>();
            if (box == null || box.isKinematic)
            {
                return;
            }
            Vector3 boxDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

           
            box.velocity = boxDir * boxPush;
        }
    }
}

