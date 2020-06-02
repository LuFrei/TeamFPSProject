using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stance { 
    Stand, 
    Crouch, 
    Prone 
}
/// <summary>
/// The "Puppet" controls for the character.
/// </summary>
public class FPSCharacterController: MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform head;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GroundCheck gc;

    //This might be moved out and to be produced by Input Manager and AI Classes
    private Vector2 moveVector;
    private Vector2 lookVector;
    public Vector2 lookAngle; //Total angle inclusing things like camera kick
    public Vector2 mouseLookAngle; //records the angle the camera should be exclusively from mouse input

    private float baseHeight;

    
    public Stance currentStance;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5;
    private float speedMultiplier = 1;
    [SerializeField] private float jumpHeight = 3;

    [Header("Camera Control Settings")]
    //Sensitivity might have to be set somewhere else, as senstiivty would be universal to general input, not individual controllable objects.
    [SerializeField] private float sensitivity = 5;
    [SerializeField] private float maxLookAngle = -90;
    [SerializeField] private float minLookAngle = 90;

    //info for current item player is holding
    [SerializeField]private UsableItem onHand;
     
    public UsableItem OnHand => onHand;
    public Vector2 MoveVector { set => moveVector = value * Time.deltaTime * (speed * speedMultiplier); }
    public Vector2 LookVector {
        set {
            lookAngle += value * Time.deltaTime * sensitivity;
            lookAngle.y = Mathf.Clamp(lookAngle.y, minLookAngle, maxLookAngle);
        }
    }
    public Stance CurrentStance => currentStance;

    private void Awake()
    {
        baseHeight = head.transform.localPosition.y;
    }
    private void FixedUpdate()
    {
        Move(moveVector);
        Look(lookAngle);
    }



    #region Movement
    public void Move(Vector2 direction)
    {
        transform.Translate(direction.x, 0, direction.y);
    }
    public void Look(Vector2 angle)
    {
        head.transform.localRotation = Quaternion.Euler(-angle.y, 0, 0); //y inverted as it seems that up is -x
        transform.localRotation = Quaternion.Euler(0, angle.x, 0);  //un-touched angles are set to current angles to allow for outside forces to effect these things (without snapping abck to 0)
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //for now we will be implementing force, however it's usually unpredictable, so I'd like to have a look into this later
    }
 
    public void ToStance(Stance stance){
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
        head.transform.localPosition = new Vector3(0, baseHeight * heightAndSpeedMultiplier, 0);

        speedMultiplier = heightAndSpeedMultiplier;

        currentStance = stance;
    }

    #endregion
    //Utilities (to be put into seperate utilities class)
    private Vector2 AddVectorToAngles(Vector2 vector, Vector2 angles)
    {

        //check constraints
        

        return angles;
    }
}
