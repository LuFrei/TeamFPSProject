using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController :  MonoBehaviour{  
    [Header("Dependencies")]
    [SerializeField] private InputManager controls;
    [SerializeField] private Transform head;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GroundCheck gc;

    //This might be moved out and to be produced by Input Manager and AI Classes
    private Vector2 moveVector;
    private Vector2 lookVector;
    private Vector2 currentLookAngle;

    private enum Stance { Stand, Crouch };
    private Stance currentStance;
     
    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    [Header("Camera Control Settings")]
    //Sensitivity might have to be set somewhere else, as senstiivty would be universal to general input, not individual controllable objects.
    [SerializeField] private float sensitivity;
    [SerializeField] private float maxVerticalAngle;
    [SerializeField] private float minVerticalAngle;

    public float Sensitivity {get; set;}

    private void Awake(){
        // To be moved to an Input handler to swap between UI, Character, and Vehicle functionality
        controls = new InputManager();
        controls.Player.Move.performed += ctx => moveVector = ctx.ReadValue<Vector2>();
        controls.Player.Look.performed += ctx => lookVector = ctx.ReadValue<Vector2>();
        controls.Player.ChangeStance.started += ctx => ToggleCrouch();
        controls.Player.Jump.performed += ctx => Jump();

        Debug.Log(transform.localScale);
    } 
    private void FixedUpdate(){
        //Again, will be moved to outer classes. Player/CPU Controller will be sinding the signals
        Move(moveVector);
        currentLookAngle = AddVectorToAngles(lookVector, currentLookAngle);
        Look(currentLookAngle);

    }

    void Move(Vector2 direction){
        direction = StandardizeVector(direction, speed);
        transform.Translate(direction.x, 0, direction.y);
    }
    void Look(Vector2 angle){

        //do rotation
        head.transform.localRotation = Quaternion.Euler(-angle.y, transform.localRotation.y, transform.localRotation.z); //y inverted as it seems that up is -x
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, angle.x, transform.localRotation.z);  //un-touched angles are set to current angles to allow for outside forces to effect these things (without snapping abck to 0)

    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //for now we will be implementing force, however it's usually unpredictable, so I'll have to look into it
    }


    //set crouching position (and speed)
    //NOTE: These contents might be moved to an animation to streamline  everything
    //I just want everything to work first, before I split everything up to different systems

    //WARNING: I see the way I've done these to fail miserably if I'm not careful, must find a smoother way to manage this
    void Crouch(){
        //bring camera down half the body height
        transform.localScale = new Vector3(1, transform.localScale.y * 0.5f, 1);
        //Slow player movement
        speed *= 0.5f;

        currentStance = Stance.Crouch;
    }

    //set standing position (and speed)
    void Stand(){
        //bring camera to full height (from crouch) 
        transform.localScale = new Vector3(1, transform.localScale.y * 2f, 1);
        //bring player speed back
        speed *= 2;

        currentStance = Stance.Stand;
    }

    void ToggleCrouch()
    {
        if (currentStance == Stance.Crouch){
            Stand();
            Debug.Log("I should be standing now");
        } else if (currentStance == Stance.Stand) {
            Crouch();
            Debug.Log("I should be crouching now");
        }
    }

    


    //Utilities (to be put into seperate utilities class)
    Vector2 AddVectorToAngles(Vector2 vector, Vector2 angles){
        vector = StandardizeVector(vector, sensitivity);

        //add vector to total angle
        angles += vector;

        //check constraints
        angles.y = Mathf.Clamp(angles.y, -90, 90);

        return angles;
    }
    /// <summary>
    /// Passes given value through Time.deltaTime, and an optional multiplier 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="multiplier">If not set, default to 1</param>
    Vector2 StandardizeVector(Vector2 value, float multiplier = 1){
        return value * Time.deltaTime * multiplier;
    }



    private void OnEnable(){
        controls.Enable();
    }
    private void OnDisable(){
        controls.Disable();
    }
    private void OnDestroy(){
        controls.Player.Move.performed -= ctx => Move(ctx.ReadValue<Vector2>());
    }
}
