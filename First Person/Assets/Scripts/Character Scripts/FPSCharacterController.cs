using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The "Puppet" controls for the character.
/// </summary>
public class FPSCharacterController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private InputManager controls;
    [SerializeField] private Transform head;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GroundCheck gc;

    //This might be moved out and to be produced by Input Manager and AI Classes
    private Vector2 moveVector;
    private Vector2 lookVector;
    private Vector2 currentLookAngle;

    private float baseHeight;

    private enum Stance { Stand, Crouch, Prone };
    private Stance currentStance;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5;
    private float speedMultiplier = 1;
    [SerializeField] private float jumpHeight = 3; 

    [Header("Camera Control Settings")]
    //Sensitivity might have to be set somewhere else, as senstiivty would be universal to general input, not individual controllable objects.
    [SerializeField] private float sensitivity = 5 ;
    [SerializeField] private float maxLookAngle = -90;
    [SerializeField] private float minLookAngle = 90;

    //I'm 100% sure there is a better way to do this, but i NEED to get something working
    [SerializeField] private UsableItem onHand;

    private void Awake()
    {
        baseHeight = transform.localScale.y;
        #region Input to Action assignment
        controls = new InputManager();
        controls.Player.Move.performed += ctx => moveVector = ctx.ReadValue<Vector2>();
        controls.Player.Look.performed += ctx => lookVector = ctx.ReadValue<Vector2>();
        controls.Player.ChangeStance.started += ctx => ToggleStance(Stance.Crouch);
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.Shoot.performed += ctx => onHand.PrimaryAction();
        #endregion
    }
    private void FixedUpdate()
    {
        Move(moveVector);
        currentLookAngle = AddVectorToAngles(lookVector, currentLookAngle);
        Look(currentLookAngle);
    }



    #region Movement
    void Move(Vector2 direction)
    {
        direction = StandardizeVector(direction, speed * speedMultiplier);
        transform.Translate(direction.x, 0, direction.y);
    }
    void Look(Vector2 angle)
    {
        head.transform.localRotation = Quaternion.Euler(-angle.y, transform.localRotation.y, transform.localRotation.z); //y inverted as it seems that up is -x
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, angle.x, transform.localRotation.z);  //un-touched angles are set to current angles to allow for outside forces to effect these things (without snapping abck to 0)

    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //for now we will be implementing force, however it's usually unpredictable, so I'd like to have a look into this later
    }
    void ToStance(Stance stance) //Neat & compact version of all "To___()" stance functions below
    {
        //determine stance & speed multiplier
        float heightAndSpeedMultiplier = 0f;
        switch (stance)
        {
            case (Stance.Stand):
                heightAndSpeedMultiplier = 1f;
                break;
            case (Stance.Crouch):
                heightAndSpeedMultiplier = 0.5f;
                break;
            case (Stance.Prone):
                heightAndSpeedMultiplier = 0.2f;
                break;
        }
        //apply multipliers
        transform.localScale = new Vector3(1, baseHeight * heightAndSpeedMultiplier, 1);

        speedMultiplier = heightAndSpeedMultiplier;

        currentStance = stance;
    }
    void ToggleStance(Stance stance)//TODO: A way to allow for individual Stance toggles (e.i. Crouch > Hold and Prone > Toggle)
    {
        if (currentStance == stance)
        {
            ToStance(Stance.Stand);
            Debug.Log("I should be standing now");
        }
        else 
        {
            ToStance(stance);
            Debug.Log("I should be crouching now");
        }
    }
    #endregion

    //Utilities (to be put into seperate utilities class)
    Vector2 AddVectorToAngles(Vector2 vector, Vector2 angles)
    {
        vector = StandardizeVector(vector, sensitivity);

        //add vector to total angle
        angles += vector;

        //check constraints
        angles.y = Mathf.Clamp(angles.y, minLookAngle, maxLookAngle);

        return angles;
    }
    /// <summary>
    /// Passes given value through Time.deltaTime, and an optional multiplier 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="multiplier">If not set, default to 1</param>
    Vector2 StandardizeVector(Vector2 value, float multiplier = 1)
    {
        return value * Time.deltaTime * multiplier;
    }

     
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void OnDestroy()
    {
        #region Disable Inputs
        controls.Player.Move.performed -= ctx => moveVector = ctx.ReadValue<Vector2>();
        controls.Player.Look.performed -= ctx => lookVector = ctx.ReadValue<Vector2>();
        controls.Player.ChangeStance.started -= ctx => ToggleStance(Stance.Crouch);
        controls.Player.Jump.performed -= ctx => Jump();
        controls.Player.Shoot.performed -= ctx => onHand.PrimaryAction();
        #endregion
    }
}
