using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerController :  MonoBehaviour{  

    [Header("Dependencies")]
    [SerializeField] private InputManager controls;
    [SerializeField] private Transform head;

    private Vector2 moveVector;
    private Vector2 lookVector;
    private Vector2 currentLookAngle;

    [Header("Movement Settings")]
    [SerializeField] private float speed;

    [Header("Camera Control Settings")]
    [SerializeField] private float sensitivity;
    [SerializeField] private float maxVerticalAngle;
    [SerializeField] private float minVerticalAngle;

    public float Sensitivity {
        get => sensitivity;
        set => sensitivity = value;
    }

    private void Awake(){
        //player = GetComponent<Player>();
        controls = new InputManager();
        controls.Player.Move.performed += ctx => moveVector = ctx.ReadValue<Vector2>();
        controls.Player.Look.performed += ctx => lookVector = ctx.ReadValue<Vector2>();
    }
    private void FixedUpdate(){
        
        Move(moveVector);
        currentLookAngle = AddVectorToAngles(lookVector, currentLookAngle);
        Look(currentLookAngle);
    }

    void Move(Vector2 direction){
        //Filter vector through Time.deltaTime and speed scale
        direction *= Time.deltaTime;
        direction *= speed;

        transform.Translate(direction.x, 0, direction.y);
    }
    void Look(Vector2 angle){


        //do rotation
        head.transform.localRotation = Quaternion.Euler(-angle.y, transform.localRotation.y, transform.localRotation.z); //y inverted as it seems that up is -x
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, angle.x, transform.localRotation.z);  //un-touched angles are set to current angles to allow for outside forces to effect these things (without snapping abck to 0)

    }
    Vector2 AddVectorToAngles(Vector2 vector, Vector2 angles){
        //Filter through deltaTime and sensitivity
        vector *= Time.deltaTime;
        vector *= sensitivity;

        //add vector to total angle
        angles += vector;

        //check constraints
        angles.y = Mathf.Clamp(angles.y, -90, 90);

        return angles;
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
