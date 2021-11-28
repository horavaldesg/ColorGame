using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    //Controller
    public static PlayerControls controls;
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
    
    [SerializeField] public CharacterController cc;

    Vector3 movement;

    [SerializeField] float speed = 3;
    [SerializeField] float speedBoost = 1;



    //LightBar
    DualShockGamepad gamepad;

    public static bool canMove;
    //Rumbles
    public InputHandler ctScheme;


    //Menu
    public GameObject OptionsObj;
    public GameObject clickScript;
    public bool PaintOnClick;
    public static bool paintOnClick;
    
    //Moveable OBJ
    public static bool hasMoveableObject;

    public float boxPush = 2.0f;
    public static bool pullBox;
    public GameObject interactionText;
    public static bool boxPickup;
    public Transform boxTransform;

    //Options Menu
    public UnityEvent changeFirstSelected;

    //Moveable Boxs
    public static GameObject moveableBox;

    //Audio
    [FMODUnity.EventRef]
    public string dragSound;

    //First Selected Obj
    public GameObject controllerObj;
    public GameObject keyboardObj;

    //Audio
    [FMODUnity.EventRef]
    public string inputSound;
    bool playerisMoving;

    private FMOD.Studio.EventInstance footsteps;

    //Player Location
    public static Vector3 playerInitialPos;

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

        //Movement
        controls.Gameplay.Move.performed += tgb => move = tgb.ReadValue<Vector2>();
        controls.Gameplay.Move.performed += tgb => PlayFootsteps();
        controls.Gameplay.Move.canceled += tgb => move = Vector3.zero;
        controls.Gameplay.Move.canceled += tgb => movement = Vector3.zero;

        //Rotation
        controls.Gameplay.Rotation.performed += tgb => rotate = tgb.ReadValue<Vector2>();
        controls.Gameplay.Rotation.canceled += tgb => rotate = Vector2.zero;


        //Options
        if (OptionsObj != null)
        {
            controls.Gameplay.Options.performed += tgb => OptionsManager();
            controls.UI1.Options.performed += tgb => OptionsManager();


            controls.Gameplay.Circle.performed += tgb => OptionsObj.SetActive(false);
            controls.UI1.Circle.performed += tgb => OptionsObj.SetActive(false);

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
        pullBox = false;

        

        //Shoot
        controls.Gameplay.Shoot.performed += tgb => ThrowableBall.Shoot(handTransform);

    }

    void Start()
    {
        InvokeRepeating("PlayFootsteps", 0, speed);
        playerInitialPos = transform.position;
    }

    public void Respawn()
    {
        cc.enabled = false;
        transform.position = playerInitialPos;
        cc.enabled = true;
        
    }
    public void OptionsManager()
    {
        OptionsObj.SetActive(!OptionsObj.activeSelf);
        //changeFirstSelected.Invoke();
        if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
        {
            GetComponentInChildren<ChangeFirstSelected>().FirstSelected(controllerObj);
        }
        else if (ctScheme.controlScheme == InputHandler.controlSchemes.Keyboard)
        {
            GetComponentInChildren<ChangeFirstSelected>().FirstSelected(keyboardObj);
        }


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
        playerisMoving = false;

    }

    public void Update()
    {
        
        if (OptionsObj.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            //InputActionMap
            controls.UI1.Enable();

            //controls.Gameplay.Disable();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            controls.UI1.Disable();

            //controls.Gameplay.Enable();
        }
        if (ctScheme.controlScheme == InputHandler.controlSchemes.Gamepad)
        {
            InputBinding actionMask = new InputBinding { groups = "Gamepad" };
            InputTextManager.inputText = "Press " + controls.Gameplay.Interaction.GetBindingDisplayString().ToUpper() + " to Interact";
            horizontalSensConst = controllerHorizontalSens.Value;
            verticalSensConst = controllerVerticalSens.Value;
            controls.bindingMask = actionMask;
        }
        else if (ctScheme.controlScheme == InputHandler.controlSchemes.Keyboard)
        {
            InputBinding actionMask = new InputBinding { groups = "KBM" };
            InputTextManager.inputText = "Press " + controls.Gameplay.Interaction.GetBindingDisplayString().ToUpper() + " to Interact";
            horizontalSensConst = horizontalSens.Value;
            verticalSensConst = verticalSens.Value;
            controls.bindingMask = actionMask;
        }
        
        
        camTransform = mainCamera.transform;

        MovePlayer();

        if (!hasMoveableObject)
        {
            cc.enabled = true;
            cc.Move(movement);
        }
        else if (hasMoveableObject)
        {
            cc.enabled = false;
        }
        RaycastHit hit;
        if (Physics.Raycast(camTransform.transform.position, camTransform.transform.forward, out hit, 2))
        {
            if (hit.collider.gameObject.CompareTag("Box"))
            {
                moveableBox = hit.collider.gameObject;
                if (moveableBox != null)
                {
                    controls.Gameplay.Interaction.performed += tgb => pullBox = !pullBox;
                }
                interactionText.SetActive(true);
                Debug.Log("Can pick up");
                boxPickup = true;
                
            }
           
        }
        else
        {
            interactionText.SetActive(false);
            
            //pullBox = false;

        }
        if (pullBox && boxPickup && moveableBox != null)
        {
            //PlayDrag(dragSound);
            moveableBox.transform.position = new Vector3(boxTransform.transform.position.x, moveableBox.transform.position.y, boxTransform.transform.position.z);
            moveableBox.transform.rotation = boxTransform.rotation;

        }
        else
        {
            moveableBox = null;
        }
        //Debug.Log(moveableBox); 
        //Player Rotation

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
        
    }

    private void MovePlayer()
    {
        movement = Vector3.zero;

        //Forward/Backward Movement
        float forwardSpeed = move.y * speed * speedBoost * Time.deltaTime;

        movement += transform.forward * forwardSpeed;

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

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Box"))
        {
            boxPickup = true;
            Rigidbody box = hit.collider.GetComponent<Rigidbody>();
            if (box == null || box.isKinematic)
            {
                return;
            }
            else
            {
                Vector3 boxDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);


                box.velocity = boxDir * boxPush;
            }
        }
        
    }

    void PlayFootsteps() 
    {
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player/Footsteps");

        //footsteps = FMODUnity.RuntimeManager.AttachInstanceToGameObject();

        footsteps.start();
        footsteps.release();
    }

    void StopFootsteps()
    {
        //footsteps.stop(FMOD.Studio.EventInstance);
    }


    void PlayDrag(string path)
    {
        FMOD.Studio.EventInstance Drag = FMODUnity.RuntimeManager.CreateInstance(path);
        Drag.start();
        Drag.release();

    }
   
}
